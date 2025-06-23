var fileSend = [];
var params;
var cid;
var urlDeleteImage = "";
var urlSaveImage = "";
var urlGetFtp = "";
var index = 1;
var indexFileName = 1;
var url = "ws://localhost:8005";
var string_byte;

$(document).on('click', '.add-picture-block', function () {
    $('.add-picture-block').html('<div class="add-scan-picture loading-scan"><i class="ion-load-a ion-loading-a "></i><br /><span>Идет сканирование...</span></div>');
    scan();
});

$(document).on('click', '#saveScanDocuments', function () {
    $('#saveScanDocuments').prop('disabled', true);

    $.ajax({
        url: urlGetFtp,
        type: "GET",
        data: { data_services_info_id: params.data_services_info_id },
        success: function (ftpModelData) {
            fileSend.forEach(function (element, index, array) {
                if (element.uploadSuccess !== true && element.uploadError !== true) {
                    $.ajax({
                        url: urlSaveImage,
                        type: "POST",
                        data: { data_services_table_id: params.data_services_table_id, data_services_info_id: params.data_services_info_id, file_name: $('.picture-block[data-index="' + index + '"] input.scan-picture-name').val(), file_size: element.image.length },
                        success: function (data) {
                            element.fileId = data.id;
                            var socket = new WebSocket(url);
                            socket.onopen = function (evt) {
                                var debug = {
                                    command: "upload",
                                    image: element.image,
                                    dataServicesInfoId: params.data_services_info_id,
                                    fileId: data.id,
                                    index: index,
                                    ftpModel: {
                                        ftpServer: ftpModelData.ftpServer,
                                        ftpLogin: ftpModelData.ftpLogin,
                                        ftpPass: ftpModelData.ftpPass,
                                        ftpFolder: ftpModelData.ftpFolder + "/Cases"
                                    }
                                };
                                var blob = new Blob([JSON.stringify(debug)], { type: 'application/json' });
                                socket.send(blob);
                            };

                            socket.onerror = function (evt) {
                                $('span.error-connect-scanapp').remove();
                                document.getElementById('pictureBlock').insertAdjacentHTML('beforeBegin', '<span class="error-connect-scanapp">Не удалось соединиться с программой для сканирования.</span>');
                                $('#saveScanDocuments').prop('disabled', false);
                            };
                            socket.onclose = function (evt) {
                                refreshDocumentFiles();
                                var closeCode = evt.code;
                                if (closeCode === 1000) {
                                    console.log('OK');
                                }
                                else {
                                    $.ajax({
                                        url: urlDeleteImage,
                                        type: "POST",
                                        async: false,
                                        data: { dataServicesFileId: element.fileId },
                                        complete: function (data) {
                                            element.uploadError = true;
                                            $('.picture-block[data-index="' + index + '"] .scan-picture').prepend('<div class="error-result"><i class="ion-alert-circled"></i></div>');
                                        }
                                    });
                                };

                                if (fileSend.length === (index + 1)) {
                                    var erCount = getCountUploadError();
                                    if (erCount === 0) {
                                        $('#myModal').modal('hide');
                                        swal({
                                            title: "Готово!",
                                            text: "Документы успешно добавлены",
                                            type: "success",
                                            confirmButtonColor: "#73c482",
                                            confirmButtonText: "Закрыть",
                                        });
                                    }
                                    else {
                                        $('#myModal .error-message').html('Не удалось сохранить ' + erCount + ' файл(ов).');
                                    }
                                }
                            };

                            socket.onmessage = function (evt) {
                                var thisSocket = this;
                                var reader = new FileReader();
                                reader.addEventListener("loadend", function () {
                                    // reader.result contains the contents of blob as a typed array
                                    var uploadResult = JSON.parse(reader.result);
                                    var result = !uploadResult.error;
                                    var fileId = uploadResult.fileId;
                                    var index = uploadResult.index;
                                    console.log(uploadResult);
                                    if (result) {
                                        $('.picture-block[data-index="' + index + '"] .scan-picture').prepend('<div class="success-result"><i class="ion-checkmark-round"></i></div>');
                                        fileSend[index].uploadSuccess = true;
                                    } else {

                                    }
                                    thisSocket.close();
                                });
                                reader.readAsText(evt.data);
                            }
                        },
                        error: function (data) {
                            errorUpload.push(index);
                            $('.picture-block[data-index="' + index + '"] .scan-picture').prepend('<div class="error-result"><i class="ion-alert-circled"></i></div>');
                            delete fileSend[index];
                        }
                    });
                }
            });


        }
    });
});

function scan() {
    var socket = new WebSocket(url);

    $('#saveScanDocuments').prop('disabled', true);
    $('.error-connect-scanapp').remove();


    socket.onopen = function (evt) {
        console.log('open scan');

        if (socket.readyState === WebSocket.OPEN) {
            var debug = { command: "scan" };
            var blob = new Blob([JSON.stringify(debug, null, 2)], { type: 'application/json' });
            socket.send(blob);
        }
    };

    socket.onclose = function (evt) {
        console.log('close scan');
        $('.loading-scan').parent().html('<div class="add-scan-picture"><i class="ion-ios7-plus-outline"></i></div>');
    };

    var dataImgae;
    // when data is comming from the server, this metod is called
    socket.onmessage = function (evt) {
        console.log('scan - ' + socket.bufferedAmount);
        var reader = new FileReader();
        reader.addEventListener("loadend", function () {
            // reader.result contains the contents of blob as a typed array
            var img = JSON.parse(reader.result);
            dataImgae = img.image;
            $('.loading-scan').parent().remove();
            $('.add-picture-block').remove();

            var picBlock = document.createElement("div");
            var scanPicDiv = document.createElement("div");
            var removePicI = document.createElement("i");
            removePicI.className = "ion-close-circled";
            picBlock.setAttribute("data-index", index);
            picBlock.className = "col-sm-6 col-md-3 picture-block";
            scanPicDiv.className = "scan-picture";
            var picImg = document.createElement("img");
            var inputName = document.createElement("input");
            inputName.className = "scan-picture-name";
            inputName.setAttribute("type", "text");
            if ($('#docTemplate').val() === "") {
                inputName.value = 'scan_' + indexFileName++;
            }
            else {
                inputName.value = $('#docTemplate option:selected').text() + "_" + indexFileName++;
            }

            picImg.setAttribute("src", "data:image/jpeg;base64," + dataImgae);

            scanPicDiv.appendChild(picImg);
            picBlock.appendChild(removePicI);
            picBlock.appendChild(inputName);
            picBlock.appendChild(scanPicDiv);
            document.getElementById('pictureBlock').appendChild(picBlock);
            document.getElementById('pictureBlock').insertAdjacentHTML('beforeend', '<div class="col-sm-6 col-md-3 add-picture-block"><div class="add-scan-picture"><i class="ion-ios7-plus-outline"></i></div></div>');
            fileSend[index++] = { image: dataImgae, fileId: '', uploadError: false, uploadSuccess: false };
            $('#saveScanDocuments').prop('disabled', false);
        });
        reader.readAsText(evt.data);
    };

    socket.onerror = function (evt) {
        $('.loading-scan').parent().html('<div class="add-scan-picture"><i class="ion-ios7-plus-outline"></i></div>');
        document.getElementById('pictureBlock').insertAdjacentHTML('beforeBegin', '<span class="error-connect-scanapp">Не удалось соединиться с программой для сканирования.</span>');
    };
}

function createScanContainer(targetId, urlSaveImageParam, urlDeleteImageParam, urlGetFtpParam, paramsParam) {
    var template = '<div class="row">' +
        '<div class="col-md-5">' +
        '<select id="docTemplate" class="form-control" name="docTemplate">' +
        '<option value>Выберите шаблон документа</option>' +
        '<option value="1">Заявление</option>' +
        '<option value="2">ИНН</option>' +
        '<option value="3">Кадастровый_паспорт</option>' +
        '<option value="4">Паспорт</option>' +
        '<option value="5">Пенсионное_удостоверение</option>' +
        '<option value="6">Регистрационное_свидетельство</option>' +
        '<option value="7">Свидетельство_о_рождении</option>' +
        '<option value="8">Свидетельство_о_браке</option>' +
        '<option value="9">СНИЛС</option>' +
        '<option value="10">Справка</option>' +
        '<option value="11">Технический_паспорт</option>' +
        '<option value="12">Трудовая_книжка</option>' +
        '<option value="13">Квитанция</option>' +
        '<option value="14">Домовая_книга</option>' +
        '<option value="15">Начисление_по_ЖКУ</option>' +
        '<option value="16">Квитанция_об_уплате</option>' +
        '<option value="17">Доверенность</option>' +
        '<option value="18">Архивная_выписка</option>' +
        '</select>' +
        '</div>' +
        '</div>';
    fileSend = [];
    index = 1;
    indexFileName = 1;
    params = paramsParam;
    urlGetFtp = urlGetFtpParam;
    urlDeleteImage = urlDeleteImageParam;
    urlSaveImage = urlSaveImageParam;
    var modalContainer = document.getElementById(targetId);
    modalContainer.innerHTML = template + '<hr class="m-b-10"/><div class="row" id="pictureBlock"><div class="col-sm-6 col-md-3 add-picture-block"><div class="add-scan-picture loading-scan"><i class="ion-ios7-plus-outline"></i><br /><span>Начать сканирование...</span></div> </div> </div> <span class="error-message"></span>';
    $('#docTemplate').select2({
        language: "ru"
    });
//    scan();
}

function getCountUploadError() {
    var countError = 0;
    fileSend.forEach((el, i, ar) => {
        if (el.uploadError === true)
            countError++;
    });
    return countError;
}

$(document).on('click', '.picture-block > i', function () {
    delete fileSend[$(this).closest('.picture-block').attr('data-index')];
    $(this).closest('.picture-block').remove();
    $('span.error-message').html('');
});
$(document).on('click', '.scan-picture', function () {
    $.fancybox.open({ src: $(this).find('img').attr('src'), openEffect: 'elastic', closeClick: true, wrapCSS: 'fancybox-custom' });
});
$(document).on('change', '#docTemplate', function () {
    if ($(this).val() !== "") {
        $("input.scan-picture-name").each(function (i, e) { $(e).val($('#docTemplate option:selected').text() + "_" + (i + 1)) });
    }
});

function openImage(fileId, infoId, type, options) {
    $.ajax({
        url: '/ScanImage/GetFtpModel',
        type: "GET",
        async: false,
        data: { data_services_info_id: infoId },
        success: function (ftpModelData) {
            var socket = new WebSocket(url);

            var dataImgae;
            // when data is comming from the server, this metod is called
            socket.onmessage = function (evt) {
                var reader = new FileReader();
                reader.addEventListener("loadend", function () {
                    // reader.result contains the contents of blob as a typed array
                    var img = JSON.parse(reader.result);
                    dataImgae = img.image;
                    $.fancybox.close();
                    if (type.toLowerCase() === '.pdf') {
                        $.fancybox.open(
                            {
                                type: 'iframe',
                                src: 'data:application/pdf;base64,' + dataImgae,
                                opts: {
                                    caption: "<div class='fs-12'>" +
                                    "<strong>Имя</strong>: " + options['name'] + "</br>" +
                                    "<strong>Размер</strong>: " + options['size'] + " кБ</br>" +
                                    "<strong>Тип</strong>: " + options['type'] + "</br>" +
                                    "<strong>Сотрудник</strong>: " + options['fio'] + "</br>" +
                                    "<strong>Дата</strong>: " + options['date'] + "</br></div>"
                                }
                            });
                    } else {
                        $.fancybox.open(
                            {
                                src: 'data:image/png;base64,' + dataImgae,
                                opts: {
                                    caption: "<div class='fs-12'>" +
                                    "<strong>Имя</strong>: " + options['name'] + "</br>" +
                                    "<strong>Размер</strong>: " + options['size'] + " кБ</br>" +
                                    "<strong>Тип</strong>: " + options['type'] + "</br>" +
                                    "<strong>Сотрудник</strong>: " + options['fio'] + "</br>" +
                                    "<strong>Дата</strong>: " + options['date'] + "</br></div>"
                                }
                            });
                    }
                    string_byte = dataImgae;
                    socket.close();
                });
                reader.readAsText(evt.data);
            };

            socket.addEventListener("open", function (evt) {
                if (socket.readyState === WebSocket.OPEN) {
                    var debug = {
                        command: "open",
                        dataServicesInfoId: infoId,
                        fileId: fileId,
                        fileExt: type.toLowerCase(),
                        ftpModel: {
                            ftpServer: ftpModelData.out_mfc_ftp_server,
                            ftpLogin: ftpModelData.out_mfc_ftp_login,
                            ftpPass: ftpModelData.out_mfc_ftp_pass,
                            ftpFolder: ftpModelData.out_mfc_ftp_folder
                        }
                    };
                    var blob = new Blob([JSON.stringify(debug)], { type: 'application/json' });
                    socket.send(blob);
                }
            }, false);

            socket.addEventListener("error", function (evt) {
                console.log("Error open file");
            }, false);
        }
    });
}

function downloadImage(fileId, infoId, type, fileName) {
    var contentType;
    $.ajax({
        url: "/ScanImage/GetFtpModel",
        type: "GET",
        async: false,
        data: { data_services_info_id: infoId },
        success: function (ftpModelData) {
            var socket = new WebSocket(url);

            var dataImgae;
            // when data is comming from the server, this metod is called
            socket.onmessage = function (evt) {
                var reader = new FileReader();
                reader.addEventListener("loadend", function () {
                    // reader.result contains the contents of blob as a typed array
                    var openFileResult = JSON.parse(reader.result);
                    if (!openFileResult.error) {
                        function b64toBlob(b64Data, contentType, sliceSize) {
                            contentType = contentType || '';
                            sliceSize = sliceSize || 512;

                            var byteCharacters = atob(b64Data);
                            var byteArrays = [];

                            for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
                                var slice = byteCharacters.slice(offset, offset + sliceSize);

                                var byteNumbers = new Array(slice.length);
                                for (var i = 0; i < slice.length; i++) {
                                    byteNumbers[i] = slice.charCodeAt(i);
                                }

                                var byteArray = new Uint8Array(byteNumbers);

                                byteArrays.push(byteArray);
                            }

                            var blob = new Blob(byteArrays, { type: contentType });
                            return blob;
                        }

                        switch (type) {
                            case '.html':
                                contentType = "text/html";
                                break;
                            case '.xml':
                                contentType = "text/xml";
                                break;

                            case '.txt':
                                contentType = "text/plain";
                                break;

                            case '.css':
                                contentType = "text/css";
                                break;

                            case '.png':
                                contentType = "image/png";
                                break;

                            case '.gif':
                                contentType = "image/gif";
                                break;

                            case '.jpg':
                                contentType = "image/jpg";
                                break;

                            case '.jpeg':
                                contentType = "image/jpeg";
                                break;

                            case '.zip':
                                contentType = "application/zip";
                                break;

                            case '.rar':
                                contentType = "application/zip";
                                break;

                            case '.doc':
                                contentType = "application/msword";
                                break;

                            case '.docx':
                                contentType = "	application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                break;

                            case '.pdf':
                                contentType = "application/pdf";
                                break;


                            default:
                                contentType = "image/jpg";
                                break;
                        }
                        var blob = b64toBlob(openFileResult.image, contentType);
                        var blobUrl = URL.createObjectURL(blob);

                        var element = document.createElement('a');
                        element.setAttribute('href', blobUrl);
                        element.setAttribute('download', fileName);
                        element.click();
                    }
                    socket.close();
                });
                reader.readAsText(evt.data);
            };

            socket.addEventListener("open", function (evt) {
                if (socket.readyState === WebSocket.OPEN) {
                    var debug = {
                        command: "open",
                        dataServicesInfoId: infoId,
                        fileId: fileId,
                        fileExt: type.toLowerCase(),
                        ftpModel: {
                            ftpServer: ftpModelData.out_mfc_ftp_server,
                            ftpLogin: ftpModelData.out_mfc_ftp_login,
                            ftpPass: ftpModelData.out_mfc_ftp_pass,
                            ftpFolder: ftpModelData.out_mfc_ftp_folder
                        }
                    };
                    var blob = new Blob([JSON.stringify(debug)], { type: 'application/json' });
                    socket.send(blob);
                }
            }, false);

            socket.addEventListener("error", function (evt) {
                console.log("Ошибка при скачивании");
            }, false);
        }
    });
}
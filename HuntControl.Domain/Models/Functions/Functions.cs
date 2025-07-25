using System.Collections.Generic;
using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EFDbContext : DbContext
    {

        /// <summary>
        /// Получаем инфо для заявления
        /// </summary>
        public virtual StatementInfoGetResult FuncStatementInfoGet(string infoId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_data_services_info_id", infoId);
            return this.Database.SqlQuery<StatementInfoGetResult>("SELECT * FROM statement_info_get(@in_data_services_info_id)", param1).FirstOrDefault();
        }

        /// <summary>
        /// Получаем список документов по услуге для заявления
        /// </summary>
        public virtual IEnumerable<StatementDocumentSelectResult> FuncStatementDocumentSelect(Guid serviceId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_data_services_id", serviceId);
            return this.Database.SqlQuery<StatementDocumentSelectResult>("SELECT * FROM statement_document_select(@in_data_services_id)", param1).ToArray();
        }



        public virtual IEnumerable<DataCustomerInfoGet> FuncDataCustomerInfoGet(Guid customerId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_data_customer_id", customerId);
            return this.Database.SqlQuery<DataCustomerInfoGet>("SELECT * FROM data_customer_info_get(@in_data_customer_id)", param1).ToArray();
        }

        /// <summary>
        /// Получаем список документов по услуге для заявления
        /// </summary>
        public virtual IEnumerable<EpguVisitTimeSelectResult> FuncEpguVisitTimeSelect()
        {
            return this.Database.SqlQuery<EpguVisitTimeSelectResult>("Select * FROM epgu_visit_time_select()").ToArray();
        }

        /// <summary>
        /// Получаем список документов по услуге для заявления
        /// </summary>
        public virtual IEnumerable<SeasonHuntingFarmAccountingResult> FuncSeasonHuntingFarmAccountingSelect(Guid animalId, short animalSex, short animalAge, short year)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_spr_animal_id", animalId);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_animal_sex", animalSex);
            NpgsqlParameter param3 = new NpgsqlParameter("@in_animal_age", animalAge);
            NpgsqlParameter param4 = new NpgsqlParameter("@in_year_", year);
            return this.Database.SqlQuery<SeasonHuntingFarmAccountingResult>("SELECT * FROM season_hunting_farm_accounting(@in_spr_animal_id, @in_animal_sex, @in_animal_age, @in_year_)", param1, param2, param3, param4).ToArray();
        }

        /// <summary>
        /// Статистика
        /// </summary>
        public virtual IEnumerable<MainCountEpguAndMfcResult> FuncMainCountEpguAndMfcSelect(int year)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_year", year);
            return this.Database.SqlQuery<MainCountEpguAndMfcResult>("SELECT * FROM main_count_epgu_and_mfc(@in_year)", param1).ToArray();
        }

        public virtual IEnumerable<MainCountHuntingFarmResult> FuncMainCountHuntingFarmSelect(int year)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_year", year);
            return this.Database.SqlQuery<MainCountHuntingFarmResult>("SELECT * FROM main_count_hunting_farm(@in_year)", param1).ToArray();
        }

        public virtual IEnumerable<MainCountIssueAndCancelledHuntingLicResult> FuncMainCountIssueAndCancelledHuntingLicSelect(int year)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_year", year);
            return this.Database.SqlQuery<MainCountIssueAndCancelledHuntingLicResult>("SELECT * FROM main_count_issue_and_cancelled_hunting_lic(@in_year)", param1).ToArray();
        }

        public virtual IEnumerable<MainCountIssueGroupTypeResult> FuncMainCountIssueGroupTypeSelect(int year)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_year", year);
            return this.Database.SqlQuery<MainCountIssueGroupTypeResult>("SELECT * FROM main_count_issue_group_type(@in_year)", param1).ToArray();
        }

        public virtual IEnumerable<MainCountViolationsResult> FuncMainCountViolationsSelect(int year)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_year", year);
            return this.Database.SqlQuery<MainCountViolationsResult>("SELECT * FROM main_count_violations(@in_year)", param1).ToArray();
        }

        public virtual MainGeneralInformationResult FuncMainGeneralInformationSelect()
        {
            return this.Database.SqlQuery<MainGeneralInformationResult>("SELECT * FROM main_general_information()").FirstOrDefault();
        }

        /// <summary>
        /// Получаем список животных к корешкам
        /// </summary>
        public virtual IEnumerable<HuntingBackAnimalSelectResult> FuncHuntingBackAnimalSelect(Guid huntingLicPermId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_data_customer_hunting_lic_perm_id", huntingLicPermId);
            return this.Database.SqlQuery<HuntingBackAnimalSelectResult>("SELECT * FROM hunting_back_animal_select(@in_data_customer_hunting_lic_perm_id)", param1).ToArray();
        }

        /// <summary>
        /// Получаем список физ. лиц
        /// </summary>
        public virtual IEnumerable<CustomerSelectResult> FuncCustomerSelect(Guid customerId, string search)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_search", search);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_data_customer_id", customerId);
            return this.Database.SqlQuery<CustomerSelectResult>("SELECT * FROM customer_select(@in_search, @in_data_customer_id)", param1, param2).ToArray();
        }

        /// <summary>
        /// Получаем список активных охотбилетов
        /// </summary>
        public virtual IEnumerable<CustomerHuntingLicenseSelectResult> FuncCustomerHuntingLicenseSelect(Guid customerId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_data_customer_id", customerId);
            return this.Database.SqlQuery<CustomerHuntingLicenseSelectResult>("SELECT * FROM customer_hunting_license_select(@in_data_customer_id)", param1).ToArray();

            //return this.Database.SqlQuery<CustomerHuntingLicenseSelectResult>(@"SELECT d.id AS out_data_customer_hunting_lic, d.serial_license || ' ' || d.number_license AS out_serial_number_license FROM data_customer_hunting_lic d 
            //WHERE d.data_customer_id = @in_data_customer_id AND d.cancelled_date IS NULL", param1).ToArray();
        }

        /// <summary>
        /// Получаем охотугодья с открытыми сезонами
        /// </summary>
        public virtual IEnumerable<HuntingFarmActiveSeasonSelectResult> FuncHuntingFarmActiveSeasonSelect(string employeeLogin)
        {
            try
            {
                NpgsqlParameter param1 = new NpgsqlParameter("@in_employees_login", employeeLogin);
                var a = this.Database.SqlQuery<HuntingFarmActiveSeasonSelectResult>("SELECT * FROM hunting_farm_active_season_select(@in_employees_login)", param1).ToArray();
                //var a = this.Database.SqlQuery<HuntingFarmActiveSeasonSelectResult>("SELECT DISTINCT  s1.id AS out_spr_hunting_farm_id, s1.hunting_farm_name AS out_hunting_farm_name" +
                //    " FROM spr_hunting_farm s1, spr_hunting_farm_season s2 WHERE s1.id = s2.spr_hunting_farm_id AND s2.date_stop >= CURRENT_DATE ORDER BY s1.hunting_farm_name", param1).ToArray();
                return a;
            }
            catch(Exception ex)
            {
                return new List<HuntingFarmActiveSeasonSelectResult>();
            }
        }

        /// <summary>
        /// Получаем список доступных групп
        /// </summary>
        public virtual IEnumerable<HuntingFarmActiveGroupTypeSelectResult> FuncHuntingFarmActiveGroupTypeSelect(Guid huntingFarmId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_spr_hunting_farm_id", huntingFarmId);
            return this.Database.SqlQuery<HuntingFarmActiveGroupTypeSelectResult>("SELECT * FROM hunting_farm_active_group_type_select(@in_spr_hunting_farm_id)", param1).ToArray();
        }

        /// <summary>
        /// Получаем список видов охоты с открытыми сезонами
        /// </summary>
        public virtual IEnumerable<HuntingFarmActiveHuntingTypeSelectResult> FuncHuntingFarmActiveHuntingTypeSelect(Guid huntingFarmSeasonId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_spr_hunting_farm_season_id", huntingFarmSeasonId);
            return this.Database.SqlQuery<HuntingFarmActiveHuntingTypeSelectResult>("SELECT * FROM hunting_farm_active_hunting_type_select(@in_spr_hunting_farm_season_id)", param1).ToArray();

            //return this.Database.SqlQuery<HuntingFarmActiveHuntingTypeSelectResult>("SELECT s.id AS out_spr_hunting_type_id, s.type_name AS out_type_name FROM spr_hunting_type s ORDER BY s.type_name",
            //    param1).ToArray();
        }

        /// <summary>
        /// Получаем список доступных животных
        /// </summary>
        public virtual IEnumerable<HuntingFarmSeasonAnimalSelectResult> FuncHuntingFarmSeasonAnimalSelect(Guid huntingFarmId, Guid animalGroupTypeId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_spr_hunting_farm_id", huntingFarmId);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_spr_animal_group_type_id", animalGroupTypeId);
            return this.Database.SqlQuery<HuntingFarmSeasonAnimalSelectResult>("SELECT * FROM hunting_farm_season_animal_select(@in_spr_hunting_farm_id, @in_spr_animal_group_type_id)", param1, param2).ToArray();
        }

        /// <summary>
        /// Получаем данные охотника
        /// </summary>
        public virtual HuntingCustomerInfoGetResultDto FuncHuntingCustomerInfoGet(Guid customerId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_data_customer_id", customerId);
            return this.Database.SqlQuery<HuntingCustomerInfoGetResultDto>("SELECT * FROM hunting_customer_info_get(@in_data_customer_id)", param1).FirstOrDefault();
        }

        /// <summary>
        /// Получаем лимиты на животных
        /// </summary>
        public virtual IEnumerable<HuntingLimitAnimalSelectResult> FuncHuntingLimitAnimalSelect(Guid huntingFarmSeasonId, Guid huntingTypeId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_spr_hunting_farm_season_id", huntingFarmSeasonId);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_spr_hunting_type_id", huntingTypeId);
            return this.Database.SqlQuery<HuntingLimitAnimalSelectResult>("SELECT * FROM hunting_limit_animal_select(@in_spr_hunting_farm_season_id, @in_spr_hunting_type_id)", param1, param2).ToArray();

            //return this.Database.SqlQuery<HuntingLimitAnimalSelectResult>("SELECT s.id, s.season_name, ss.date_start, ss.date_stop FROM spr_season s, spr_season_open ss WHERE s.id = ss.spr_season_id AND ss.date_stop >= CURRENT_DATE ORDER BY s.season_name, ss.date_start;", param1, param2).ToArray();
        }

        /// <summary>
        /// Получаем лимиты на бланки
        /// </summary>
        public virtual IEnumerable<HuntingLimitFormsGetResult> FuncHuntingLimitFormsGet(Guid huntingFarmSeasonId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_spr_hunting_farm_season_id", huntingFarmSeasonId);
            return this.Database.SqlQuery<HuntingLimitFormsGetResult>("SELECT * FROM hunting_limit_forms_get(@in_spr_hunting_farm_season_id)", param1).ToArray();
        }

        /// <summary>
        /// Получаем уведомления и напоминания
        /// </summary>
        public virtual IEnumerable<AlertEmployeeSelectResult> FuncAlertEmployeeSelect(Guid employeeId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_spr_employees_id", employeeId);
            return this.Database.SqlQuery<AlertEmployeeSelectResult>("SELECT * FROM alert_employee_select(@in_spr_employees_id)", param1).ToArray();
        }

        /// <summary>
        /// Получаем список файлов по номеру дела
        /// </summary>
        public virtual IEnumerable<CaseServicesFileSelectResult> FuncCaseServicesFileSelect(string infoId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_data_services_info_id", infoId);
            return this.Database.SqlQuery<CaseServicesFileSelectResult>("SELECT * FROM case_services_file_select(@in_data_services_info_id)", param1).ToArray();
        }

        /// <summary>
        /// Получаем список СМЭВ запросов
        /// </summary>
        public virtual IEnumerable<CaseServicesSmevSelectResult> FuncCaseServicesSmevSelect(Guid serviceId, Guid employeeId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_data_services_id", serviceId);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_spr_employees_id", employeeId);
            return this.Database.SqlQuery<CaseServicesSmevSelectResult>("SELECT * FROM case_services_smev_select(@in_data_services_id, @in_spr_employees_id)", param1, param2).ToArray();
        }

        /// <summary>
        /// Получаем список СМЭВ запросов
        /// </summary>
        public virtual IEnumerable<CaseServicesSmevRequestSelectResult> FuncCaseServicesSmevRequestSelect(Guid serviceId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_data_services_id", serviceId);
            return this.Database.SqlQuery<CaseServicesSmevRequestSelectResult>("SELECT * FROM case_services_smev_request_select(@in_data_services_id)", param1).ToArray();
        }

        /// <summary>
        /// Получаем список файлов по документу
        /// </summary>
        public virtual IEnumerable<CaseServicesDocumentFileSelectResult> FuncCaseServicesDocumentFileSelect(Guid documentId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_data_services_table_id", documentId);
            return this.Database.SqlQuery<CaseServicesDocumentFileSelectResult>("SELECT * FROM case_services_document_file_select(@in_data_services_table_id)", param1).ToArray();
        }

        /// <summary>
        /// Получаем список документов по услуге
        /// </summary>
        public virtual IEnumerable<CaseServicesDocumentSelectResult> FuncCaseServicesDocumentSelect(Guid serviceId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_data_services_id", serviceId);
            return this.Database.SqlQuery<CaseServicesDocumentSelectResult>("SELECT * FROM case_services_document_select(@in_data_services_id)", param1).ToArray();
        }

        /// <summary>
        /// Получаем список этапов по услуге
        /// </summary>
        public virtual IEnumerable<CaseServicesRoutesStageSelectResult> FuncCaseServicesRoutesStageSelect(Guid serviceId, Guid employeeId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_data_services_id", serviceId);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_spr_employees_id", employeeId);
            return this.Database.SqlQuery<CaseServicesRoutesStageSelectResult>("SELECT * FROM case_services_routes_stage_select(@in_data_services_id, @in_spr_employees_id)", param1, param2).ToArray();
        }

        /// <summary>
        /// Получаем список следующего этапа по услуге
        /// </summary>
        public virtual IEnumerable<CaseServicesRoutesStageNextSelectResult> FuncCaseServicesRoutesStageNextSelect(Guid serviceId, Guid employeeId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_data_services_id", serviceId);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_spr_employees_id", employeeId);
            return this.Database.SqlQuery<CaseServicesRoutesStageNextSelectResult>("SELECT * FROM case_services_routes_stage_next_select(@in_data_services_id, @in_spr_employees_id)", param1, param2).ToArray();
        }

        /// <summary>
        /// Получаем инфо по услуге
        /// </summary>
        public virtual CaseServicesInfoGetResult FuncCaseServicesInfoGet(string infoId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_data_services_info_id", infoId);
            return this.Database.SqlQuery<CaseServicesInfoGetResult>("SELECT * FROM case_services_info_get(@in_data_services_info_id)", param1).FirstOrDefault();
        }

        /// <summary>
        /// Получаем обращения
        /// </summary>
        public virtual IEnumerable<CaseSelectResult> FuncCaseSelect(Guid employeeId, DateTime startDate, DateTime stopDate, Guid? serviceSubId, short? serviceSubStatusId, Guid? servicesSubWayGetId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_spr_employees_id", employeeId);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_date_start", (NpgsqlDate)startDate);
            NpgsqlParameter param3 = new NpgsqlParameter("@in_date_stop", (NpgsqlDate)stopDate);
            NpgsqlParameter param4 = new NpgsqlParameter("@in_spr_services_sub_id", (object)serviceSubId ?? DBNull.Value);
            NpgsqlParameter param5 = new NpgsqlParameter("@in_spr_services_sub_status_id", (object)serviceSubStatusId ?? DBNull.Value);
            NpgsqlParameter param6 = new NpgsqlParameter("@in_spr_services_sub_way_get_id", (object)servicesSubWayGetId ?? DBNull.Value);
            return this.Database.SqlQuery<CaseSelectResult>("SELECT * FROM case_select(@in_spr_employees_id, @in_date_start, @in_date_stop, @in_spr_services_sub_id, @in_spr_services_sub_status_id, @in_spr_services_sub_way_get_id)", param1, param2, param3, param4, param5, param6).ToList();
        }
        /// <summary>
        /// Получаем архив
        /// </summary>
        public virtual IEnumerable<CaseSelectResult> FuncCaseArchiveSelect(Guid employeeId, Guid in_spr_employees_id_execution, DateTime startDate, DateTime stopDate, Guid? serviceSubId, short? serviceSubStatusId, Guid? servicesSubWayGetId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_spr_employees_id", employeeId);
            NpgsqlParameter param7 = new NpgsqlParameter("@in_spr_employees_id_execution", in_spr_employees_id_execution);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_date_start", (NpgsqlDate)startDate);
            NpgsqlParameter param3 = new NpgsqlParameter("@in_date_stop", (NpgsqlDate)stopDate);
            NpgsqlParameter param4 = new NpgsqlParameter("@in_spr_services_sub_id", (object)serviceSubId ?? DBNull.Value);
            NpgsqlParameter param5 = new NpgsqlParameter("@in_spr_services_sub_status_id", (object)serviceSubStatusId ?? DBNull.Value);
            NpgsqlParameter param6 = new NpgsqlParameter("@in_spr_services_sub_way_get_id", (object)servicesSubWayGetId ?? DBNull.Value);
            return this.Database.SqlQuery<CaseSelectResult>("SELECT * FROM case_archive_services(@in_spr_employees_id, @in_spr_employees_id_execution, @in_date_start, @in_date_stop, @in_spr_services_sub_id, @in_spr_services_sub_status_id, @in_spr_services_sub_way_get_id)", param1, param7, param2, param3, param4, param5, param6).ToList();
        }

        /// <summary>
        /// Получаем данные заявителя
        /// </summary>
        public virtual GetCustomerInfoResult FuncGetCustomerInfo(string customerDocSerial, string customerDocNumber)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_customer_doc_serial", customerDocSerial);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_customer_doc_number", customerDocNumber);
            return this.Database.SqlQuery<GetCustomerInfoResult>("SELECT * FROM customer_info_get(@in_customer_doc_serial, @in_customer_doc_number)", param1, param2).FirstOrDefault();
        }

        /// <summary>
        /// Получаем услуги по типу заявителя
        /// </summary>
        public virtual IEnumerable<SprServicesSubSelectResult> FuncSprServicesSubSelect()
        {
            //NpgsqlParameter param1 = new NpgsqlParameter("@in_spr_services_sub_type_recipient_id", recipient);
            return this.Database.SqlQuery<SprServicesSubSelectResult>("SELECT * FROM spr_services_sub_select()").ToArray();
        }

        /// <summary>
        /// Получаем услуги по типу заявителя
        /// </summary>
        public virtual IEnumerable<SprServicesSubCustomerTypeRecipientSelect> FuncSprServicesSubCustomerTypeRecipientSelect(Guid servicesSubId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_spr_services_sub_id", servicesSubId);
            return this.Database.SqlQuery<SprServicesSubCustomerTypeRecipientSelect>("SELECT * FROM spr_services_sub_customer_type_recipient_select(@in_spr_services_sub_id)", param1).ToArray();
        }

        /// <summary>
        /// Получаем тарифы по типу услуги
        /// </summary>
        public virtual IEnumerable<SprServicesSubTariffSelectResult> FuncSprServicesSubTariffSelect(Guid sprServicesSubId, int recipient)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_spr_services_sub_id", sprServicesSubId);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_spr_services_sub_type_recipient_id", recipient);
            return this.Database.SqlQuery<SprServicesSubTariffSelectResult>("SELECT * FROM spr_services_sub_tariff_select(@in_spr_services_sub_id, @in_spr_services_sub_type_recipient_id)", param1, param2).ToArray();
        }

        /// <summary>
        /// Отчет по реестру выданных охотничьих билетов по дате
        /// </summary>
        public virtual IEnumerable<ReportHuntingLicIssuedReestrResult> FuncReportHuntingLicIssuedReestr(DateTime dateStart, DateTime dateStop)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_date_start", (NpgsqlDate)dateStart);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_date_stop", (NpgsqlDate)dateStop);
            return this.Database.SqlQuery<ReportHuntingLicIssuedReestrResult>("SELECT * FROM report_hunting_lic_issued_reestr(@in_date_start, @in_date_stop)", param1, param2).ToArray();
        }

        /// <summary>
        /// Отчет по реестру выданных охотничьих билетов по номеру 
        /// </summary>
        public virtual IEnumerable<ReportHuntingLicIssuedReestrResult> FuncReportHuntingLicIssuedNumberReestr(int numberStart, int numberStop)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_number_start", numberStart);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_number_stop", numberStop);
            return this.Database.SqlQuery<ReportHuntingLicIssuedReestrResult>("SELECT * FROM report_hunting_lic_issued_reestr_number(@in_number_start, @in_number_stop)", param1, param2).ToArray();
        }

        /// <summary>
        /// Отчет по реестру аннулированных охотничьих билетов 
        /// </summary>
        public virtual IEnumerable<ReportHuntingLicCancelledReestrResult> FuncReportHuntingLicCancelledNumderReestr(int numberStart, int numberStop)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_number_start", numberStart);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_number_stop", numberStop);
            return this.Database.SqlQuery<ReportHuntingLicCancelledReestrResult>("SELECT * FROM report_hunting_lic_cancelled_reestr_number(@in_number_start, @in_number_stop)", param1, param2).ToArray();
        }

        /// <summary>
        /// Отчет по реестру аннулированных охотничьих билетов 
        /// </summary>
        public virtual IEnumerable<ReportHuntingLicCancelledReestrResult> FuncReportHuntingLicCancelledReestr(DateTime dateStart, DateTime dateStop)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_date_start", (NpgsqlDate)dateStart);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_date_stop", (NpgsqlDate)dateStop);
            return this.Database.SqlQuery<ReportHuntingLicCancelledReestrResult>("SELECT * FROM report_hunting_lic_cancelled_reestr(@in_date_start, @in_date_stop)", param1, param2).ToArray();
        }

        /// <summary>
        /// Отчет Реестр по количеству услуг
        /// </summary>
        public virtual IEnumerable<ReportReestrCountServiceResult> FuncReportReestrCountService(DateTime dateStart, DateTime dateStop, int subServiceStatusId, Guid subServiceWayGetId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_date_start", (NpgsqlDate)dateStart);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_date_stop", (NpgsqlDate)dateStop);
            NpgsqlParameter param3 = new NpgsqlParameter("@in_spr_services_sub_status_id", subServiceStatusId);
            NpgsqlParameter param4 = new NpgsqlParameter("@in_spr_services_sub_way_get_id", subServiceWayGetId);
            return this.Database.SqlQuery<ReportReestrCountServiceResult>("SELECT * FROM report_reestr_count_service(@in_date_start, @in_date_stop, @in_spr_services_sub_status_id, @in_spr_services_sub_way_get_id)", param1, param2, param3, param4).ToArray();
        }

        /// <summary>
        /// Отчет Реестр нарушений
        /// </summary>
        public virtual IEnumerable<ReportDataCustomerViolationsReestrResult> FuncReportReestrDataCustomerViolations(DateTime dateStart, DateTime dateStop, Guid? sprEmployeesId, Guid? sprEmployeesDepartmentId, Guid? sprViolationsId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_date_start", (NpgsqlDate)dateStart);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_date_stop", (NpgsqlDate)dateStop);
            NpgsqlParameter param3 = new NpgsqlParameter("@in_spr_employees_id", (object)sprEmployeesId ?? DBNull.Value);
            NpgsqlParameter param4 = new NpgsqlParameter("@in_spr_employees_department_id", (object)sprEmployeesDepartmentId ?? DBNull.Value);
            NpgsqlParameter param5 = new NpgsqlParameter("@in_spr_violations_id", (object)sprViolationsId ?? DBNull.Value);
            return this.Database.SqlQuery<ReportDataCustomerViolationsReestrResult>("SELECT * FROM report_reestr_violations(@in_date_start, @in_date_stop, @in_spr_employees_id, @in_spr_employees_department_id, @in_spr_violations_id)", param1, param2, param3, param4, param5).ToArray();
        }

        /// <summary>
        /// Получаем нарушения
        /// </summary>
        public virtual IEnumerable<ViolationSelectResult> FuncViolationSelect(Guid? employeeId, DateTime startDate, DateTime stopDate, int? statusId, int? documentId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_date_start", (NpgsqlDate)startDate);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_date_stop", (NpgsqlDate)stopDate);
            NpgsqlParameter param3 = new NpgsqlParameter("@in_spr_violations_status_id", (object)statusId ?? DBNull.Value);
            NpgsqlParameter param4 = new NpgsqlParameter("@in_spr_violations_document_id", (object)documentId ?? DBNull.Value);
            NpgsqlParameter param5 = new NpgsqlParameter("@in_spr_employees_id", (object)employeeId ?? DBNull.Value);
            return this.Database.SqlQuery<ViolationSelectResult>("SELECT * FROM violations_select(@in_date_start, @in_date_stop, @in_spr_violations_status_id, @in_spr_violations_document_id, @in_spr_employees_id)", param1, param2, param3, param4, param5).ToList();
        }

        /// <summary>
        /// Получаем нарушителей
        /// </summary>
        public virtual IEnumerable<ViolationsCustomerSelectResult> FuncViolationsCustomerSelect(Guid? employeeId, DateTime startDate, DateTime stopDate, int? statusId, int? documentId, Guid? sprViolationsId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_date_start", (NpgsqlDate)startDate);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_date_stop", (NpgsqlDate)stopDate);
            NpgsqlParameter param3 = new NpgsqlParameter("@in_spr_violations_status_id", (object)statusId ?? DBNull.Value);
            NpgsqlParameter param4 = new NpgsqlParameter("@in_spr_violations_document_id", (object)documentId ?? DBNull.Value);
            NpgsqlParameter param5 = new NpgsqlParameter("@in_spr_employees_id", (object)employeeId ?? DBNull.Value);
            NpgsqlParameter param6 = new NpgsqlParameter("@in_spr_violations_id", (object)sprViolationsId ?? DBNull.Value);
            return this.Database.SqlQuery<ViolationsCustomerSelectResult>("SELECT * FROM violations_customer_select(@in_date_start, @in_date_stop, @in_spr_violations_status_id, @in_spr_violations_document_id, @in_spr_employees_id, @in_spr_violations_id)", param1, param2, param3, param4, param5, param6).ToList();
        }

        /// <summary>
        /// Получаем нарушения физ. лица
        /// </summary>
        public virtual IEnumerable<CustomerViolationsSelectResult> FuncCustomerViolationsSelect(Guid dataCustomerId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_data_customer_id", dataCustomerId);
            return this.Database.SqlQuery<CustomerViolationsSelectResult>("SELECT * FROM customer_violations_select(@in_data_customer_id)", param1).ToList();
        }
        /// <summary>
        /// Получаем животных в сезоне за год (исправить названия)
        /// </summary>
        public virtual IEnumerable<CustomerHuntingSeason> FuncGetCustomerHuntingSeason(int spr_season_id, int year)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_spr_season_id", spr_season_id);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_year_", year);
            return this.Database.SqlQuery<CustomerHuntingSeason>("SELECT * FROM spr_season_animal_select(@in_spr_season_id, @in_year_)", param1, param2).ToList();
        }

        /// <summary>
        /// Получаем данные разрешения
        /// </summary>
        public virtual HuntingLicPermsResult FuncGetHuntingLicPermsResult(Guid dataCustomerHuntingLicPermId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_data_customer_hunting_lic_perm_id", dataCustomerHuntingLicPermId);
            return this.Database.SqlQuery<HuntingLicPermsResult>("SELECT * FROM statement_lic_perm_info_get(@in_data_customer_hunting_lic_perm_id)", param1).FirstOrDefault();
        }

        /// <summary>
        /// Реестр разрешений на охоту без корешков
        /// </summary>
        public virtual IEnumerable<ReportHuntingLicNotPermBackResult> FuncReportHuntingLicNotPermBackReestr(DateTime startDate, DateTime stopDate, Guid in_spr_animal_group_type_id,Guid in_spr_animal_id, Guid in_spr_hunting_farm_id)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_date_start", (NpgsqlDate)startDate);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_date_stop", (NpgsqlDate)stopDate);
            NpgsqlParameter param3 = new NpgsqlParameter("@in_spr_animal_group_type_id", in_spr_animal_group_type_id);
            NpgsqlParameter param4 = new NpgsqlParameter("@in_spr_animal_id", in_spr_animal_id);
            NpgsqlParameter param5 = new NpgsqlParameter("@in_spr_hunting_farm_id", in_spr_hunting_farm_id);
            var res = this.Database.SqlQuery<ReportHuntingLicNotPermBackResult>("SELECT * FROM report_hunting_lic_not_perm_back(@in_date_start, @in_date_stop, @in_spr_animal_group_type_id, @in_spr_animal_id, @in_spr_hunting_farm_id)", param1, param2, param3, param4, param5).ToList();
            return res;
        }

        /// <summary>
        /// Реестр разрешений на охоту
        /// </summary>
        public virtual IEnumerable<ReportHuntingLicPermResult> FuncReportHuntingLicPerm(int? sprSeasonId, Guid? animalId, DateTime startDate, DateTime stopDate, Guid? sprHuntingFarmId)
        {

            NpgsqlParameter param1 = new NpgsqlParameter("@in_spr_hunting_farm_id", (object)sprHuntingFarmId ?? DBNull.Value);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_date_start", (NpgsqlDate)startDate);
            NpgsqlParameter param3 = new NpgsqlParameter("@in_date_stop", (NpgsqlDate)stopDate);
            NpgsqlParameter param4 = new NpgsqlParameter("@in_spr_season_id", (object)sprSeasonId ?? DBNull.Value);
            NpgsqlParameter param5 = new NpgsqlParameter("@in_spr_animal_id", (object)animalId ?? DBNull.Value);

            return this.Database.SqlQuery<ReportHuntingLicPermResult>("SELECT * FROM report_hunting_lic_perm(@in_spr_hunting_farm_id, @in_date_start, @in_date_stop, @in_spr_season_id, @in_spr_animal_id)", param1, param2, param3, param4, param5).ToList();
        }

        /// <summary>
        /// Количество нарушений по охотугодьям
        /// </summary>
        public virtual IEnumerable<ReportCountViolationsHuntingFarm> FuncReportCountViolationsHuntingFarm(DateTime startDate, DateTime stopDate, Guid? sprEmployeesId, Guid? sprEmployeesDepartmentId, Guid? sprViolationsId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_date_start", (NpgsqlDate)startDate);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_date_stop", (NpgsqlDate)stopDate);
            NpgsqlParameter param3 = new NpgsqlParameter("@in_spr_employees_id", (object)sprEmployeesId ?? DBNull.Value);
            NpgsqlParameter param4 = new NpgsqlParameter("@in_spr_employees_department_id", (object)sprEmployeesDepartmentId ?? DBNull.Value);
            NpgsqlParameter param5 = new NpgsqlParameter("@in_spr_violations_id", (object)sprViolationsId ?? DBNull.Value);
            return this.Database.SqlQuery<ReportCountViolationsHuntingFarm>("SELECT * FROM report_count_violations_hunting_farm(@in_date_start, @in_date_stop, @in_spr_employees_id, @in_spr_employees_department_id, @in_spr_violations_id)", param1, param2, param3, param4, param5).ToList();
        }

        /// <summary>
        /// Количество нарушений по сотрудникам
        /// </summary>
        public virtual IEnumerable<ReportCountViolationsEmployees> FuncReportCountViolationsEmployees(DateTime startDate, DateTime stopDate, Guid? sprViolationsId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_date_start", (NpgsqlDate)startDate);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_date_stop", (NpgsqlDate)stopDate);
            NpgsqlParameter param3 = new NpgsqlParameter("@in_spr_violations_id", (object)sprViolationsId ?? DBNull.Value);
            return this.Database.SqlQuery<ReportCountViolationsEmployees>("SELECT * FROM report_count_violations_employees(@in_date_start, @in_date_stop, @in_spr_violations_id)", param1, param2, param3).ToList();
        }

        /// <summary>
        /// Количество нарушений по статьям
        /// </summary>
        public virtual IEnumerable<ReportCountViolations> FuncReportCountViolations(DateTime startDate, DateTime stopDate, Guid? sprEmployeesDepartmentId, Guid? sprViolationsId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_date_start", (NpgsqlDate)startDate);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_date_stop", (NpgsqlDate)stopDate);
            NpgsqlParameter param3 = new NpgsqlParameter("@in_spr_employees_department_id", (object)sprEmployeesDepartmentId ?? DBNull.Value);
            NpgsqlParameter param4 = new NpgsqlParameter("@in_spr_violations_id", (object)sprViolationsId ?? DBNull.Value);
            return this.Database.SqlQuery<ReportCountViolations>("SELECT * FROM report_count_violations(@in_date_start, @in_date_stop, @in_spr_employees_department_id, @in_spr_violations_id)", param1, param2, param3, param4).ToList();
        }

        /// <summary>
        /// Общий отчет по разрешению в разрезе охотоугодий
        /// </summary>
        public virtual IEnumerable<ReportTotalHuntingFarmResult> FuncReportTotalHuntingFarm(Guid? huntingFarmTypeId, Guid? animalGroupTypeId, Guid? animalId, DateTime startDate, DateTime stopDate)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_spr_hunting_farm_type_id", (object)huntingFarmTypeId ?? DBNull.Value);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_spr_animal_group_type_id", (object)animalGroupTypeId ?? DBNull.Value);
            NpgsqlParameter param3 = new NpgsqlParameter("@in_spr_animal_id", (object)animalId ?? DBNull.Value);
            NpgsqlParameter param4 = new NpgsqlParameter("@in_date_start", (NpgsqlDate)startDate);
            NpgsqlParameter param5 = new NpgsqlParameter("@in_date_stop", (NpgsqlDate)stopDate);
            return this.Database.SqlQuery<ReportTotalHuntingFarmResult>("SELECT * FROM report_total_hunting_farm(@in_spr_hunting_farm_type_id, @in_spr_animal_group_type_id, @in_spr_animal_id, @in_date_start, @in_date_stop)", param1, param2, param3, param4, param5).ToList();
        }

        /// <summary>
        /// Отчет по разрешению в разрезе групп
        /// </summary>
        public virtual IEnumerable<ReportTotalHuntingGroupResult> FuncReportTotalHuntingGroup(Guid? huntingFarmId, Guid? huntingFarmTypeId, DateTime startDate, DateTime stopDate)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_spr_hunting_farm_id", (object)huntingFarmId ?? DBNull.Value);
            NpgsqlParameter param2 = new NpgsqlParameter("@in_spr_hunting_farm_type_id", (object)huntingFarmTypeId ?? DBNull.Value);
            NpgsqlParameter param3 = new NpgsqlParameter("@in_date_start", (NpgsqlDate)startDate);
            NpgsqlParameter param4 = new NpgsqlParameter("@in_date_stop", (NpgsqlDate)stopDate);
            return this.Database.SqlQuery<ReportTotalHuntingGroupResult>("SELECT * FROM report_total_hunting_group(@in_spr_hunting_farm_id, @in_spr_hunting_farm_type_id, @in_date_start, @in_date_stop)", param1, param2, param3, param4).ToList();
        }

        /// <summary>
        /// Получаем настройки FTP
        /// </summary>
        public virtual FtpSettings FuncGetFtpSettings()
        {
            return this.Database.SqlQuery<FtpSettings>("SELECT * FROM ftp_settings_get()").FirstOrDefault();
        }

        /// <summary>
        /// Функция получения данных для бланка по копытным животным
        /// </summary>
        public virtual FormUngulateInfoResult FuncFormUngulateInfo(Guid huntingLicPermId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_data_customer_hunting_lic_perm_id", huntingLicPermId);
            return this.Database.SqlQuery<FormUngulateInfoResult>("SELECT * FROM form_ungulate_info(@in_data_customer_hunting_lic_perm_id)", param1).FirstOrDefault();
        }

        /// <summary>
        /// Функция получения данных для бланка по копытным медведям
        /// </summary>
        public virtual FormBearInfoResult FuncFormBearInfo(Guid huntingLicPermId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_data_customer_hunting_lic_perm_id", huntingLicPermId);
            return this.Database.SqlQuery<FormBearInfoResult>("SELECT * FROM form_bear_info(@in_data_customer_hunting_lic_perm_id)", param1).FirstOrDefault();
        }

        /// <summary>
        /// Функция получения данных для бланка по птицам
        /// </summary>
        public virtual FormBirdInfoResult FuncFormBirdInfo(Guid huntingLicPermId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_data_customer_hunting_lic_perm_id", huntingLicPermId);
            return this.Database.SqlQuery<FormBirdInfoResult>("SELECT * FROM form_bird_info(@in_data_customer_hunting_lic_perm_id)", param1).FirstOrDefault();
        }

        /// <summary>
        /// Функция получения данных для бланка по пушным животным
        /// </summary>
        public virtual FormFurInfoResult FuncFormFurInfo(Guid huntingLicPermId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_data_customer_hunting_lic_perm_id", huntingLicPermId);
            return this.Database.SqlQuery<FormFurInfoResult>("SELECT * FROM form_fur_info(@in_data_customer_hunting_lic_perm_id)", param1).FirstOrDefault();
        }

        /// <summary>
        /// Функция получения списка животных к бланку
        /// </summary>
        public virtual IEnumerable<FormAnimalSelectResult> FuncFormAnimalSelect(Guid huntingLicPermId)
        {
            NpgsqlParameter param1 = new NpgsqlParameter("@in_data_customer_hunting_lic_perm_id", huntingLicPermId);
            return this.Database.SqlQuery<FormAnimalSelectResult>("SELECT * FROM form_animal_select(@in_data_customer_hunting_lic_perm_id)", param1).ToList();
        }
    }
}

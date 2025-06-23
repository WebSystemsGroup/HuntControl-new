using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HuntControl.Domain.Abstract;
using HuntControl.Domain.Models.Entities;

namespace HuntControl.Domain.Concrete
{
    public partial class EFRepository : IRepository
    {
        private EFDbContext context = new EFDbContext();

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Таблицы  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public IQueryable<data_employees_alert> DataEmployeeAlerts => context.data_employees_alert;
        public IQueryable<data_employees_reminder> DataEmployeeReminders => context.data_employees_reminder;

        public IQueryable<data_change_log> DataChangeLogs => context.data_change_log;
        public IQueryable<data_calendar> DataCalendars => context.data_calendar;
        public IQueryable<data_calendar_day_type> DataCalendarDayTypes => context.data_calendar_day_type;
        public IQueryable<data_system_errors> DataSystemErrors => context.data_system_errors;
        public IQueryable<data_services> DataServices => context.data_services;
        public IQueryable<data_services_document> DataServicesDocuments => context.data_services_document;
        public IQueryable<data_services_file> DataServicesFiles => context.data_services_file;
        public IQueryable<data_services_customer> DataServicesCustomers => context.data_services_customer;
        public IQueryable<data_services_smev_request> DataServicesSmevRequests => context.data_services_smev_request;
        public IQueryable<data_services_smev_request_status> DataServicesSmevRequestStatuses => context.data_services_smev_request_status;
        public IQueryable<data_services_commentt> DataServicesComments => context.data_services_commentt;
        public IQueryable<data_services_commentt_recipient> DataServicesCommentsRecipients => context.data_services_commentt_recipient;
        public IQueryable<data_services_smev_log> DataServicesSmevLogs => context.data_services_smev_log;

        public IQueryable<data_customer> DataCustomers => context.data_customer;
        public IQueryable<data_customer_violations> DataCustomerViolations => context.data_customer_violations;
        public IQueryable<data_customer_violations_file> DataCustomerViolationsFile => context.data_customer_violations_file;
        public IQueryable<data_customer_hunting_lic> DataCustomerHuntingLics => context.data_customer_hunting_lic;
        public IQueryable<data_customer_hunting_lic_perm> DataCustomerHuntingLicPerms => context.data_customer_hunting_lic_perm;
        public IQueryable<data_customer_hunting_lic_perm_hunting> DataCustomerHuntingLicPermHuntings => context.data_customer_hunting_lic_perm_hunting;
        public IQueryable<data_customer_hunting_lic_perm_animal> DataCustomerHuntingLicPermAnimals => context.data_customer_hunting_lic_perm_animal;
        public IQueryable<data_customer_hunting_lic_perm_back> DataCustomerHuntingLicPermBacks => context.data_customer_hunting_lic_perm_back;
        public IQueryable<data_customer_hunting_lic_perm_payment> DataCustomerHuntingLicPermPayments => context.data_customer_hunting_lic_perm_payment;
        public IQueryable<data_customer_hunting_lic_perm_back_animal> DataCustomerHuntingLicPermBackAnimals => context.data_customer_hunting_lic_perm_back_animal;
        public IQueryable<data_services_routes_stage> DataServicesRoutesStages => context.data_services_routes_stage;

        public IQueryable<epgu_slot_time> EpguSlotTimes => context.epgu_slot_time;
        public IQueryable<epgu_slot_time_book> EpguSlotTimeBooks => context.epgu_slot_time_book;


        public IQueryable<spr_settings> SprSettings => context.spr_settings;


        public IQueryable<spr_account> SprAccounts => context.spr_account;
        public IQueryable<spr_animal> SprAnimals => context.spr_animal;
        public IQueryable<spr_animal_group> SprAnimalGroups => context.spr_animal_group;
        public IQueryable<spr_animal_group_type> SprAnimalGroupTypes => context.spr_animal_group_type;
        public IQueryable<spr_animal_location> SprAnimalLocations => context.spr_animal_location;
        public IQueryable<spr_animal_hunting_type_join> SprAnimalHuntingTypeJoins => context.spr_animal_hunting_type_join;
        public IQueryable<spr_animal_method_account> SprAnimalMethodAccounts => context.spr_animal_method_account;
        public IQueryable<spr_bank> SprBanks => context.spr_bank;
        public IQueryable<spr_season> SprSeasons => context.spr_season;
        public IQueryable<spr_season_open> SprSeasonOpens => context.spr_season_open;
        public IQueryable<spr_season_animal> SprSeasonAnimals => context.spr_season_animal;
        public IQueryable<spr_season_open_animal> SprSeasonOpenAnimals => context.spr_season_open_animal;
        public IQueryable<spr_hunting_lic_status> SprHuntingLicStatus => context.spr_hunting_lic_status;
        public IQueryable<spr_hunting_farm> SprHuntingFarms => context.spr_hunting_farm;
        public IQueryable<spr_hunting_farm_location> SprHuntingFarmLocations => context.spr_hunting_farm_location;
        public IQueryable<spr_hunting_farm_season> SprHuntingFarmSeasons => context.spr_hunting_farm_season;
        public IQueryable<spr_hunting_farm_season_animal> SprHuntingFarmSeasonAnimals => context.spr_hunting_farm_season_animal;
        public IQueryable<spr_hunting_farm_season_forms> SprHuntingFarmSeasonForms => context.spr_hunting_farm_season_forms;
        public IQueryable<spr_hunting_farm_limit> SprHuntingFarmLimits => context.spr_hunting_farm_limit;
        public IQueryable<spr_hunting_farm_accounting> SprHuntingFarmAccountings => context.spr_hunting_farm_accounting;
        public IQueryable<spr_hunting_farm_type> SprHuntingFarmTypes => context.spr_hunting_farm_type;
        public IQueryable<spr_hunting_farm_animal> SprHuntingFarmAnimals => context.spr_hunting_farm_animal;
        public IQueryable<spr_hunting_type> SprHuntingTypes => context.spr_hunting_type;
        public IQueryable<spr_method_remove> SprMethodRemoves => context.spr_method_remove;
        public IQueryable<spr_legal_person> SprLegalPersons => context.spr_legal_person;

        public IQueryable<spr_employees> SprEmployees => context.spr_employees;
        public IQueryable<spr_employees_job_pos> SprEmployeesJobPos => context.spr_employees_job_pos;
        public IQueryable<spr_employees_hunting_farm> SprEmployeesHuntingFarms => context.spr_employees_hunting_farm;
        public IQueryable<spr_employees_role> SprEmployeesRoles => context.spr_employees_role;
        public IQueryable<spr_employees_role_join> SprEmployeesRoleJoins => context.spr_employees_role_join;
        public IQueryable<spr_employees_department> SprEmployeesDepartments => context.spr_employees_department;

        public IQueryable<spr_documents> SprDocuments => context.spr_documents;
        public IQueryable<spr_document_identity> SprDocumentIdentities => context.spr_document_identity;

        public IQueryable<spr_routes_stage> SprRoutesStages => context.spr_routes_stage;
        public IQueryable<spr_taxation> SprTaxations => context.spr_taxation;
        public IQueryable<spr_violations> SprViolations => context.spr_violations;
        public IQueryable<spr_violations_part> SprViolationsPart => context.spr_violations_part;
        public IQueryable<spr_violations_status> SprViolationsStatus => context.spr_violations_status;
        public IQueryable<spr_violations_document> SprViolationsDocument => context.spr_violations_document;

        public IQueryable<spr_definition_type> SprDefinitionTypes => context.spr_definition_type;
        public IQueryable<spr_bailiffs> SprBailiffs => context.spr_bailiffs;
        public IQueryable<spr_organization> SprOrganizations => context.spr_organization;

        public IQueryable<spr_bailiffs_result> SprBailiffsResult => context.spr_bailiffs_result;
        public IQueryable<spr_organization_result> SprOrganizationsResult => context.spr_organization_result;



        #region ////////////////////////////"Сервисы СМЭВ"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        public IQueryable<spr_smev> SprSmevServices => context.spr_smev;
        public IQueryable<spr_smev_request> SprSmevRequests => context.spr_smev_request;
        public IQueryable<spr_smev_type_request> SprSmevRequestTypes => context.spr_smev_type_request;


        #endregion

        #region ////////////////////////////"Услуги"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        public IQueryable<spr_services> SprServices => context.spr_services;
        public IQueryable<spr_services_type> SprServicesTypes => context.spr_services_type;
        public IQueryable<spr_services_sub> SprServicesSubs => context.spr_services_sub;
        public IQueryable<spr_services_sub_status> SprServicesSubStatuses => context.spr_services_sub_status;
        public IQueryable<spr_services_sub_active> SprServicesSubActives => context.spr_services_sub_active;
        public IQueryable<spr_services_sub_result_doc> SprServicesSubResultDocs => context.spr_services_sub_result_doc;
        public IQueryable<spr_services_sub_customer> SprServicesSubCustomers => context.spr_services_sub_customer;
        public IQueryable<spr_services_sub_document> SprServicesSubDocuments => context.spr_services_sub_document;
        public IQueryable<spr_services_sub_document_customer> SprServicesSubDocumentCustomers => context.spr_services_sub_document_customer;
        public IQueryable<spr_services_sub_failure> SprServicesSubFailures => context.spr_services_sub_failure;
        public IQueryable<spr_services_sub_failure_doc> SprServicesSubFailureDocs => context.spr_services_sub_failure_doc;
        public IQueryable<spr_services_sub_tariff> SprServicesSubTariffs => context.spr_services_sub_tariff;
        public IQueryable<spr_services_sub_tariff_type> SprServicesSubTariffTypes => context.spr_services_sub_tariff_type;
        public IQueryable<spr_services_sub_type_recipient> SprServicesSubTypeRecipients => context.spr_services_sub_type_recipient;
        public IQueryable<spr_services_sub_type_quality> SprServicesSubTypeQualities => context.spr_services_sub_type_quality;
        public IQueryable<spr_services_sub_type_quality_join> SprServicesSubTypeQualityJoins => context.spr_services_sub_type_quality_join;
        public IQueryable<spr_services_sub_way_get> SprServicesSubWayGets => context.spr_services_sub_way_get;
        public IQueryable<spr_services_sub_way_get_join> SprServicesSubWayGetJoins => context.spr_services_sub_way_get_join;
        public IQueryable<spr_services_sub_way_get_result> SprServicesSubWayGetResults => context.spr_services_sub_way_get_result;
        public IQueryable<spr_services_sub_way_get_result_join> SprServicesSubWayGetResultJoins => context.spr_services_sub_way_get_result_join;
        public IQueryable<spr_services_sub_file_folder> SprServicesSubFileFolders => context.spr_services_sub_file_folder;
        public IQueryable<spr_services_sub_file> SprServicesSubFiles => context.spr_services_sub_file;
        public IQueryable<spr_services_sub_week> SprServicesSubWeeks => context.spr_services_sub_week;
        public IQueryable<spr_services_sub_smev_request_join> SprServicesSubSmevRequests => context.spr_services_sub_smev_request_join;

        #endregion

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Функции  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public StatementInfoGetResult FuncStatementInfoGet(string infoId) => context.FuncStatementInfoGet(infoId);
        public IEnumerable<EpguVisitTimeSelectResult> FuncEpguVisitTimeSelect() => context.FuncEpguVisitTimeSelect();
        public IEnumerable<StatementDocumentSelectResult> FuncStatementDocumentSelect(Guid serviceId) => context.FuncStatementDocumentSelect(serviceId);
        public IEnumerable<DataCustomerInfoGet> FuncDataCustomerInfoGet(Guid customerId) => context.FuncDataCustomerInfoGet(customerId);
        public IEnumerable<HuntingBackAnimalSelectResult> FuncHuntingBackAnimalSelect(Guid huntingLicPermId) => context.FuncHuntingBackAnimalSelect(huntingLicPermId);
        public IEnumerable<CustomerSelectResult> FuncCustomerSelect(Guid customerId, string search) => context.FuncCustomerSelect(customerId, search);
        public IEnumerable<CustomerHuntingLicenseSelectResult> FuncCustomerHuntingLicenseSelect(Guid customerId) => context.FuncCustomerHuntingLicenseSelect(customerId);
        public HuntingCustomerInfoGetResultDto FuncHuntingCustomerInfoGetDto(Guid customerId) => context.FuncHuntingCustomerInfoGet(customerId);
        public IEnumerable<HuntingFarmActiveSeasonSelectResult> FuncHuntingFarmActiveSeasonSelect(string employeeLogin) => context.FuncHuntingFarmActiveSeasonSelect(employeeLogin);
        public IEnumerable<HuntingFarmActiveGroupTypeSelectResult> FuncHuntingFarmActiveGroupTypeSelect(Guid huntingFarmId) => context.FuncHuntingFarmActiveGroupTypeSelect(huntingFarmId);
        public IEnumerable<HuntingFarmActiveHuntingTypeSelectResult> FuncHuntingFarmActiveHuntingTypeSelect(Guid huntingFarmSeasonId) => context.FuncHuntingFarmActiveHuntingTypeSelect(huntingFarmSeasonId);
        public IEnumerable<HuntingFarmSeasonAnimalSelectResult> FuncHuntingFarmSeasonAnimalSelect(Guid huntingFarmId, Guid animalGroupTypeId) => context.FuncHuntingFarmSeasonAnimalSelect(huntingFarmId, animalGroupTypeId);
        public IEnumerable<HuntingLimitAnimalSelectResult> FuncHuntingLimitAnimalSelect(Guid huntingFarmSeasonId, Guid huntingTypeId) => context.FuncHuntingLimitAnimalSelect(huntingFarmSeasonId, huntingTypeId);
        public IEnumerable<HuntingLimitFormsGetResult> FuncHuntingLimitFormsGet(Guid huntingFarmSeasonId) => context.FuncHuntingLimitFormsGet(huntingFarmSeasonId);
        public IEnumerable<AlertEmployeeSelectResult> FuncAlertEmployeeSelect(Guid employeeId) => context.FuncAlertEmployeeSelect(employeeId);
        public IEnumerable<CaseServicesFileSelectResult> FuncCaseServicesFileSelect(string infoId) => context.FuncCaseServicesFileSelect(infoId);
        public IEnumerable<CaseServicesDocumentSelectResult> FuncCaseServicesDocumentSelect(Guid serviceId) => context.FuncCaseServicesDocumentSelect(serviceId);
        public IEnumerable<CaseServicesSmevSelectResult> FuncCaseServicesSmevSelect(Guid serviceId, Guid employeeId) => context.FuncCaseServicesSmevSelect(serviceId, employeeId);
        public IEnumerable<CaseServicesSmevRequestSelectResult> FuncCaseServicesSmevRequestSelect(Guid serviceId) => context.FuncCaseServicesSmevRequestSelect(serviceId);
        public IEnumerable<CaseServicesDocumentFileSelectResult> FuncCaseServicesDocumentFileSelect(Guid documentId) => context.FuncCaseServicesDocumentFileSelect(documentId);
        public IEnumerable<CaseServicesRoutesStageSelectResult> FuncCaseServicesRoutesStageSelect(Guid serviceId, Guid employeeId) => context.FuncCaseServicesRoutesStageSelect(serviceId, employeeId);
        public IEnumerable<CaseServicesRoutesStageNextSelectResult> FuncCaseServicesRoutesStageNextSelect(Guid serviceId, Guid employeeId) => context.FuncCaseServicesRoutesStageNextSelect(serviceId, employeeId);
        public CaseServicesInfoGetResult FuncCaseServicesInfoGet(string infoId) => context.FuncCaseServicesInfoGet(infoId);
        public IEnumerable<CaseSelectResult> FuncCaseSelect(Guid employeeId, DateTime startDate, DateTime stopDate, Guid? serviceSubId, short? serviceSubStatusId, Guid? servicesSubWayGetId) => context.FuncCaseSelect(employeeId, startDate, stopDate, serviceSubId, serviceSubStatusId, servicesSubWayGetId);

        public IEnumerable<CaseSelectResult> FuncCaseArchiveSelect(Guid employeeId, Guid in_spr_employees_id_execution, DateTime startDate, DateTime stopDate, Guid? serviceSubId, short? serviceSubStatusId, Guid? servicesSubWayGetId) => context.FuncCaseArchiveSelect(employeeId, in_spr_employees_id_execution, startDate, stopDate, serviceSubId, serviceSubStatusId, servicesSubWayGetId);

        public GetCustomerInfoResult FuncGetCustomerInfo(string customerDocSerial, string customerDocNumber) => context.FuncGetCustomerInfo(customerDocSerial, customerDocNumber);
        public IEnumerable<SprServicesSubSelectResult> FuncSprServicesSubSelect() => context.FuncSprServicesSubSelect();
        public IEnumerable<SprServicesSubCustomerTypeRecipientSelect> FuncSprServicesSubCustomerTypeRecipientSelect(Guid servicesSubId) => context.FuncSprServicesSubCustomerTypeRecipientSelect(servicesSubId);
        public IEnumerable<SprServicesSubTariffSelectResult> FuncSprServicesSubTariffSelect(Guid sprServicesSubId, int recipient) => context.FuncSprServicesSubTariffSelect(sprServicesSubId, recipient);
        public HuntingLicPermsResult FuncGetHuntingLicPermsResult(Guid dataCustomerHuntingLicPermId) => context.FuncGetHuntingLicPermsResult(dataCustomerHuntingLicPermId);
        public IEnumerable<ViolationSelectResult> FuncViolationSelect(Guid? employeeId, DateTime startDate, DateTime stopDate, int? statusId, int? documentId) => context.FuncViolationSelect(employeeId, startDate, stopDate, statusId, documentId);
        public IEnumerable<ViolationsCustomerSelectResult> FuncViolationsCustomerSelect(Guid? employeeId, DateTime startDate, DateTime stopDate, int? statusId, int? documentId, Guid? sprViolationId) => context.FuncViolationsCustomerSelect(employeeId, startDate, stopDate, statusId, documentId, sprViolationId);
        public IEnumerable<CustomerViolationsSelectResult> FuncCustomerViolationsSelect(Guid dataCustomerId) => context.FuncCustomerViolationsSelect(dataCustomerId);

        #region исправить названия

        public IEnumerable<CustomerHuntingSeason> FuncGetCustomerHuntingSeason(int spr_season_id, int year) => context.FuncGetCustomerHuntingSeason(spr_season_id, year);
        #endregion




        public IEnumerable<ReportHuntingLicIssuedReestrResult> FuncReportHuntingLicIssuedReestr(DateTime dateStart, DateTime dateStop) => context.FuncReportHuntingLicIssuedReestr(dateStart, dateStop);
        public IEnumerable<ReportHuntingLicIssuedReestrResult> FuncReportHuntingLicIssuedNumberReestr(int numberStart, int numberStop) => context.FuncReportHuntingLicIssuedNumberReestr(numberStart, numberStop); 
        public IEnumerable<ReportHuntingLicCancelledReestrResult> FuncReportHuntingLicCancelledReestr(DateTime dateStart, DateTime dateStop) => context.FuncReportHuntingLicCancelledReestr(dateStart, dateStop);
        public IEnumerable<ReportReestrCountServiceResult> FuncReportReestrCountService(DateTime dateStart, DateTime dateStop, int subServiceStatusId, Guid subServiceWayGetId) => context.FuncReportReestrCountService(dateStart, dateStop, subServiceStatusId, subServiceWayGetId);
        public IEnumerable<ReportDataCustomerViolationsReestrResult> FuncReportReestrDataCustomerViolations(DateTime dateStart, DateTime dateStop, Guid? sprEmployeesId, Guid? sprEmployeesDepartmentId, Guid? sprViolationsId) => context.FuncReportReestrDataCustomerViolations(dateStart, dateStop, sprEmployeesId, sprEmployeesDepartmentId, sprViolationsId);
        public IEnumerable<ReportHuntingLicNotPermBackResult> FuncReportHuntingLicNotPermBackReestr(DateTime dateStart, DateTime dateStop, Guid IdGroupType, Guid IdAnimals, Guid IdHuntingFarm) => context.FuncReportHuntingLicNotPermBackReestr( dateStart,  dateStop,  IdGroupType,  IdAnimals,  IdHuntingFarm);
        public IEnumerable<ReportHuntingLicPermResult> FuncReportHuntingLicPerm(int? sprSeasonId, Guid? animalId, DateTime startDate, DateTime stopDate, Guid? sprHuntingFarmId) => context.FuncReportHuntingLicPerm(sprSeasonId, animalId, startDate, stopDate, sprHuntingFarmId);
        public IEnumerable<ReportCountViolationsHuntingFarm> FuncReportCountViolationsHuntingFarm(DateTime startDate, DateTime stopDate, Guid? sprEmployeesId, Guid? sprEmployeesDepartmentId, Guid? sprViolationsId) => context.FuncReportCountViolationsHuntingFarm(startDate, stopDate, sprEmployeesId, sprEmployeesDepartmentId, sprViolationsId);
        public IEnumerable<ReportCountViolationsEmployees> FuncReportCountViolationsEmployees(DateTime startDate, DateTime stopDate, Guid? sprViolationsId) => context.FuncReportCountViolationsEmployees(startDate, stopDate, sprViolationsId);
        public IEnumerable<ReportCountViolations> FuncReportCountViolations(DateTime startDate, DateTime stopDate, Guid? sprEmployeesDepartmentId, Guid? sprViolationsId) => context.FuncReportCountViolations(startDate, stopDate, sprEmployeesDepartmentId, sprViolationsId);
        public IEnumerable<ReportTotalHuntingFarmResult> FuncReportTotalHuntingFarm(Guid? huntingFarmTypeId, Guid? animalGroupTypeId, Guid? animalId, DateTime startDate, DateTime stopDate) => context.FuncReportTotalHuntingFarm(huntingFarmTypeId, animalGroupTypeId, animalId, startDate, stopDate);
        public IEnumerable<ReportTotalHuntingGroupResult> FuncReportTotalHuntingGroup(Guid? huntingFarmId, Guid? huntingFarmTypeId, DateTime startDate, DateTime stopDate) => context.FuncReportTotalHuntingGroup(huntingFarmId, huntingFarmTypeId, startDate, stopDate);
        public FormUngulateInfoResult FuncFormUngulateInfo(Guid huntingLicPermId) => context.FuncFormUngulateInfo(huntingLicPermId);
        public FormBearInfoResult FuncFormBearInfo(Guid huntingLicPermId) => context.FuncFormBearInfo(huntingLicPermId);
        public FormBirdInfoResult FuncFormBirdInfo(Guid huntingLicPermId) => context.FuncFormBirdInfo(huntingLicPermId);
        public FormFurInfoResult FuncFormFurInfo(Guid huntingLicPermId) => context.FuncFormFurInfo(huntingLicPermId);
        public IEnumerable<FormAnimalSelectResult> FuncFormAnimalSelect(Guid huntingLicPermId) => context.FuncFormAnimalSelect(huntingLicPermId);
        public IEnumerable<SeasonHuntingFarmAccountingResult> FuncSeasonHuntingFarmAccountingSelect(Guid animalId, short animalSex, short animalAge, short year) => context.FuncSeasonHuntingFarmAccountingSelect(animalId, animalSex, animalAge, year);

        public IEnumerable<MainCountEpguAndMfcResult> FuncMainCountEpguAndMfcSelect(int year) => context.FuncMainCountEpguAndMfcSelect(year);
        public IEnumerable<MainCountHuntingFarmResult> FuncMainCountHuntingFarmSelect(int year) => context.FuncMainCountHuntingFarmSelect(year);
        public IEnumerable<MainCountIssueAndCancelledHuntingLicResult> FuncMainCountIssueAndCancelledHuntingLicSelect(int year) => context.FuncMainCountIssueAndCancelledHuntingLicSelect(year);
        public IEnumerable<MainCountIssueGroupTypeResult> FuncMainCountIssueGroupTypeSelect(int year) => context.FuncMainCountIssueGroupTypeSelect(year);
        public IEnumerable<MainCountViolationsResult> FuncMainCountViolationsSelect(int year) => context.FuncMainCountViolationsSelect(year);
        public MainGeneralInformationResult FuncMainGeneralInformationSelect() => context.FuncMainGeneralInformationSelect();



        public FtpSettings FuncGetFtpSettings() => context.FuncGetFtpSettings();


        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Методы CRUD таблиц  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|



        //////-----------//////-----------//////-----------//////    Текущие данные    \\\\\\-----------\\\\\\-----------\\\\\\-----------\\\\\\


        #region ////////////////////////////"Услуги"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        /// <summary>
        /// сохраняет изменения записей
        /// </summary>
        /// <param name="service">объект услуги</param>
        public void SaveDataService(data_services service)
        {
            if (service.id == Guid.Empty)
            {
                context.data_services.Add(service);
            }
            else
            {
                data_services dbEntry = context.data_services.Find(service.id);
                if (dbEntry != null)
                {
                    dbEntry.commentt = service.commentt;
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// удаляет запись по id
        /// </summary>
        /// <param name="serviceId">id услуги</param>
        /// <returns>возвращает какая запись была удалена</returns>
        public data_services DeleteDataService(Guid serviceId)
        {
            data_services dbEntry = context.data_services.Find(serviceId);
            if (dbEntry != null)
            {
                context.data_services.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        #endregion

        #region ////////////////////////////"Заявитель (Услуги)"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        /// <summary>
        /// сохраняет изменения записей
        /// </summary>
        /// <param name="customer">объект Заявителя</param>
        public void SaveDataServiceCustomer(data_services_customer customer)
        {
            if (customer.id == Guid.Empty)
            {
                context.data_services_customer.Add(customer);
            }
            else
            {
                data_services_customer dbEntry = context.data_services_customer.Find(customer.id);
                if (dbEntry != null)
                {
                    dbEntry.customer_sex = customer.customer_sex;
                    dbEntry.customer_snils = customer.customer_snils;
                    dbEntry.employees_fio_modifi = customer.employees_fio_modifi;
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// удаляет запись по id
        /// </summary>
        /// <param name="customerId">id Заявителя</param>
        /// <returns>возвращает какая запись была удалена</returns>
        public data_services_customer DeleteDataServiceCustomer(Guid customerId)
        {
            data_services_customer dbEntry = context.data_services_customer.Find(customerId);
            if (dbEntry != null)
            {
                context.data_services_customer.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        #endregion


        #region ////////////////////////////"Заявитель (Охотник)"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        /// <summary>
        /// сохраняет изменения записей
        /// </summary>
        /// <param name="customer">объект Заявителя</param>
        public void SaveCustomer(data_customer customer)
        {
            if (customer.id == Guid.Empty)
            {
                context.data_customer.Add(customer);
            }
            else
            {
                data_customer dbEntry = context.data_customer.Find(customer.id);
                if (dbEntry != null)
                {
                    dbEntry.actual_address = customer.actual_address;
                    dbEntry.legal_address = customer.legal_address;
                    dbEntry.customer_name = customer.customer_name;
                    dbEntry.customer_sex = customer.customer_sex;
                    dbEntry.customer_snils = customer.customer_snils;
                    dbEntry.doc_birth_place = customer.doc_birth_place;
                    dbEntry.doc_birth_date = customer.doc_birth_date;
                    dbEntry.doc_code = customer.doc_code;
                    dbEntry.doc_number = customer.doc_number;
                    dbEntry.doc_serial = customer.doc_serial;
                    dbEntry.doc_issue_body = customer.doc_issue_body;
                    dbEntry.e_mail = customer.e_mail;
                    dbEntry.phone_number1 = customer.phone_number1;
                    dbEntry.phone_number2 = customer.phone_number2;
                    dbEntry.employees_fio_modifi = customer.employees_fio_modifi;
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// удаляет запись по id
        /// </summary>
        /// <param name="customerId">id Заявителя</param>
        /// <returns>возвращает какая запись была удалена</returns>
        public data_customer DeleteCustomer(Guid customerId)
        {
            data_customer dbEntry = context.data_customer.Find(customerId);
            if (dbEntry != null)
            {
                context.data_customer.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        #endregion



        //////-----------//////-----------//////-----------//////    Справочники    \\\\\\-----------\\\\\\-----------\\\\\\-----------\\\\\\


        #region Методы CRUD таблицы "Виды охотхозяйств"

        /// <summary>
        /// сохраняет изменения записей вида охотхозяйства
        /// </summary>
        /// <param name="huntingFarmType">объект вид охотхозяйства</param>
        public void SaveHuntingFarmType(spr_hunting_farm_type huntingFarmType)
        {
            if (huntingFarmType.id == Guid.Empty)
            {
                context.spr_hunting_farm_type.Add(huntingFarmType);
            }
            else
            {
                spr_hunting_farm_type dbEntry = context.spr_hunting_farm_type.Find(huntingFarmType.id);
                if (dbEntry != null)
                {
                    dbEntry.type_name = huntingFarmType.type_name;
                    dbEntry.employees_fio_modifi = huntingFarmType.employees_fio_modifi;
                    dbEntry.employees_fio = huntingFarmType.employees_fio;
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// удаляет запись по id
        /// </summary>
        /// <param name="huntingFarmTypeId">id вида охотхозяйства</param>
        /// <returns>возвращает какая запись была удалена</returns>
        public spr_hunting_farm_type DeleteHuntingFarmType(Guid huntingFarmTypeId)
        {
            spr_hunting_farm_type dbEntry = context.spr_hunting_farm_type.Find(huntingFarmTypeId);
            if (dbEntry != null)
            {
                context.spr_hunting_farm_type.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        #endregion


        #region ////////////////////////////"Документы к услуге"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        /// <summary>
        /// сохраняет изменения записей
        /// </summary>
        /// <param name="subServiceDocument">объект документа к услуге</param>
        public void SaveSubServiceDocument(spr_services_sub_document subServiceDocument)
        {
            if (subServiceDocument.id == Guid.Empty)
            {
                context.spr_services_sub_document.Add(subServiceDocument);
            }
            else
            {
                spr_services_sub_document dbEntry = context.spr_services_sub_document.Find(subServiceDocument.id);
                if (dbEntry != null)
                {
                    dbEntry.document_count = subServiceDocument.document_count;
                    dbEntry.document_needs = subServiceDocument.document_needs;
                    dbEntry.document_type = subServiceDocument.document_type;
                    dbEntry.commentt = subServiceDocument.commentt;
                    dbEntry.employees_fio_modifi = subServiceDocument.employees_fio_modifi;
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// удаляет запись по id
        /// </summary>
        /// <param name="subServiceDocumentId">id документа  к услуге</param>
        /// <returns>возвращает какая запись была удалена</returns>
        public spr_services_sub_document DeleteSubServiceDocument(Guid subServiceDocumentId)
        {
            spr_services_sub_document dbEntry = context.spr_services_sub_document.Find(subServiceDocumentId);
            if (dbEntry != null)
            {
                context.spr_services_sub_document.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        #endregion

        #region ////////////////////////////"Результаты документов к услуге"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        /// <summary>
        /// сохраняет изменения записей
        /// </summary>
        /// <param name="subServiceResultDoc">объект результата документа к услуге</param>
        public void SaveSubServiceResultDoc(spr_services_sub_result_doc subServiceResultDoc)
        {
            if (subServiceResultDoc.id == Guid.Empty)
            {
                context.spr_services_sub_result_doc.Add(subServiceResultDoc);
            }
            else
            {
                spr_services_sub_result_doc dbEntry = context.spr_services_sub_result_doc.Find(subServiceResultDoc.id);
                if (dbEntry != null)
                {
                    dbEntry.document_method = subServiceResultDoc.document_method;
                    dbEntry.document_result = subServiceResultDoc.document_result;
                    dbEntry.document_period_provider = subServiceResultDoc.document_period_provider;
                    dbEntry.spr_documents_id = subServiceResultDoc.spr_documents_id;
                    dbEntry.commentt = subServiceResultDoc.commentt;
                    dbEntry.employees_fio_modifi = subServiceResultDoc.employees_fio_modifi;
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// удаляет запись по id
        /// </summary>
        /// <param name="subServiceResultDocId">id результата документа  к услуге</param>
        /// <returns>возвращает какая запись была удалена</returns>
        public spr_services_sub_result_doc DeleteSubServiceResultDoc(Guid subServiceResultDocId)
        {
            spr_services_sub_result_doc dbEntry = context.spr_services_sub_result_doc.Find(subServiceResultDocId);
            if (dbEntry != null)
            {
                context.spr_services_sub_result_doc.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        #endregion

        #region ////////////////////////////"Заявители"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        /// <summary>
        /// сохраняет изменения записей
        /// </summary>
        /// <param name="subServiceCustomer">объект заявителя</param>
        public void SaveSubServiceCustomer(spr_services_sub_customer subServiceCustomer)
        {
            if (subServiceCustomer.id == Guid.Empty)
            {
                context.spr_services_sub_customer.Add(subServiceCustomer);
            }
            else
            {
                spr_services_sub_customer dbEntry = context.spr_services_sub_customer.Find(subServiceCustomer.id);
                if (dbEntry != null)
                {
                    dbEntry.spr_services_sub_type_recipient_id = subServiceCustomer.spr_services_sub_type_recipient_id;
                    dbEntry.representative = subServiceCustomer.representative;
                    dbEntry.representative_document = subServiceCustomer.representative_document;
                    dbEntry.representative_list = subServiceCustomer.representative_list;
                    dbEntry.representative_specification = subServiceCustomer.representative_specification;
                    dbEntry.commentt = subServiceCustomer.commentt;
                    dbEntry.employees_fio_modifi = subServiceCustomer.employees_fio_modifi;
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// удаляет запись по id
        /// </summary>
        /// <param name="subServiceCustomerId">id заявителя</param>
        /// <returns>возвращает какая запись была удалена</returns>
        public spr_services_sub_customer DeleteSubServiceCustomer(Guid subServiceCustomerId)
        {
            spr_services_sub_customer dbEntry = context.spr_services_sub_customer.Find(subServiceCustomerId);
            if (dbEntry != null)
            {
                context.spr_services_sub_customer.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        #endregion

        #region ////////////////////////////"Тарифы заявителя"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        /// <summary>
        /// сохраняет изменения записей
        /// </summary>
        /// <param name="customerTariff">объект тарифа заявителя</param>
        public void SaveSubServiceCustomerTariff(spr_services_sub_tariff customerTariff)
        {
            if (customerTariff.id == Guid.Empty)
            {
                context.spr_services_sub_tariff.Add(customerTariff);
            }
            else
            {
                spr_services_sub_tariff dbEntry = context.spr_services_sub_tariff.Find(customerTariff.id);
                if (dbEntry != null)
                {
                    dbEntry.count_day_execution = customerTariff.count_day_execution;
                    dbEntry.count_day_processing = customerTariff.count_day_processing;
                    dbEntry.count_day_return = customerTariff.count_day_return;
                    dbEntry.spr_services_sub_week_id = customerTariff.spr_services_sub_week_id;
                    dbEntry.spr_services_sub_tariff_type_id = customerTariff.spr_services_sub_tariff_type_id;
                    dbEntry.tariff_ = customerTariff.tariff_;
                    dbEntry.commentt = customerTariff.commentt;
                    dbEntry.employees_fio_modifi = customerTariff.employees_fio_modifi;
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// удаляет запись по id
        /// </summary>
        /// <param name="customerTariffId">id тарифа заявителя</param>
        /// <returns>возвращает какая запись была удалена</returns>
        public spr_services_sub_tariff DeleteSubServiceCustomerTariff(Guid customerTariffId)
        {
            spr_services_sub_tariff dbEntry = context.spr_services_sub_tariff.Find(customerTariffId);
            if (dbEntry != null)
            {
                context.spr_services_sub_tariff.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        #endregion

        #region ////////////////////////////"Документы заявителя"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        /// <summary>
        /// сохраняет изменения записей
        /// </summary>
        /// <param name="customerDocument">объект документа заявителя</param>
        public void SaveSubServiceCustomerDocument(spr_services_sub_document_customer customerDocument)
        {
            if (customerDocument.id == Guid.Empty)
            {
                context.spr_services_sub_document_customer.Add(customerDocument);
            }
            else
            {
                spr_services_sub_document_customer dbEntry = context.spr_services_sub_document_customer.Find(customerDocument.id);
                if (dbEntry != null)
                {
                    dbEntry.document_count = customerDocument.document_count;
                    dbEntry.document_needs = customerDocument.document_needs;
                    dbEntry.document_type = customerDocument.document_type;
                    dbEntry.commentt = customerDocument.commentt;
                    dbEntry.employees_fio_modifi = customerDocument.employees_fio_modifi;
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// удаляет запись по id
        /// </summary>
        /// <param name="customerDocumentId">id документа заявителя</param>
        /// <returns>возвращает какая запись была удалена</returns>
        public spr_services_sub_document_customer DeleteSubServiceCustomerDocument(Guid customerDocumentId)
        {
            spr_services_sub_document_customer dbEntry = context.spr_services_sub_document_customer.Find(customerDocumentId);
            if (dbEntry != null)
            {
                context.spr_services_sub_document_customer.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        #endregion

        #region ////////////////////////////"Отказ приема документов"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        /// <summary>
        /// сохраняет изменения записей
        /// </summary>
        /// <param name="subServiceFailureDoc">объект отказ приёма документов</param>
        public void SaveSubServiceFailureDoc(spr_services_sub_failure_doc subServiceFailureDoc)
        {
            if (subServiceFailureDoc.id == Guid.Empty)
            {
                context.spr_services_sub_failure_doc.Add(subServiceFailureDoc);
            }
            else
            {
                spr_services_sub_failure_doc dbEntry = context.spr_services_sub_failure_doc.Find(subServiceFailureDoc.id);
                if (dbEntry != null)
                {
                    dbEntry.failure_text = subServiceFailureDoc.failure_text;
                    dbEntry.legal_act = subServiceFailureDoc.legal_act;
                    dbEntry.commentt = subServiceFailureDoc.commentt;
                    dbEntry.employees_fio_modifi = subServiceFailureDoc.employees_fio_modifi;
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// удаляет запись по id
        /// </summary>
        /// <param name="subServiceFailureDocId">id отказа приёма документов</param>
        /// <returns>возвращает какая запись была удалена</returns>
        public spr_services_sub_failure_doc DeleteSubServiceFailureDoc(Guid subServiceFailureDocId)
        {
            spr_services_sub_failure_doc dbEntry = context.spr_services_sub_failure_doc.Find(subServiceFailureDocId);
            if (dbEntry != null)
            {
                context.spr_services_sub_failure_doc.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        #endregion

        #region ////////////////////////////"Отказ предоставления услуги"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        /// <summary>
        /// сохраняет изменения записей
        /// </summary>
        /// <param name="subServiceFailure">объект отказа предоставления услуги</param>
        public void SaveSubServiceFailure(spr_services_sub_failure subServiceFailure)
        {
            if (subServiceFailure.id == Guid.Empty)
            {
                context.spr_services_sub_failure.Add(subServiceFailure);
            }
            else
            {
                spr_services_sub_failure dbEntry = context.spr_services_sub_failure.Find(subServiceFailure.id);
                if (dbEntry != null)
                {
                    dbEntry.failure_text = subServiceFailure.failure_text;
                    dbEntry.legal_act = subServiceFailure.legal_act;
                    dbEntry.commentt = subServiceFailure.commentt;
                    dbEntry.employees_fio_modifi = subServiceFailure.employees_fio_modifi;
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// удаляет запись по id
        /// </summary>
        /// <param name="subServiceFailureId">id отказа предоставления услуги</param>
        /// <returns>возвращает какая запись была удалена</returns>
        public spr_services_sub_failure DeleteSubServiceFailure(Guid subServiceFailureId)
        {
            spr_services_sub_failure dbEntry = context.spr_services_sub_failure.Find(subServiceFailureId);
            if (dbEntry != null)
            {
                context.spr_services_sub_failure.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        #endregion


        #region ////////////////////////////"Способ обращения за услугой"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        /// <summary>
        /// сохраняет изменения записей
        /// </summary>
        /// <param name="subServiceWayGet">объект способа обращения за услугой</param>
        public void SaveSubServiceWayGet(spr_services_sub_way_get_join subServiceWayGet)
        {
            context.spr_services_sub_way_get_join.Add(subServiceWayGet);
            context.SaveChanges();
        }

        /// <summary>
        /// удаляет запись по id
        /// </summary>
        /// <param name="subServiceWayGetId">id способа обращения за услугой</param>
        /// <returns>возвращает какая запись была удалена</returns>
        public spr_services_sub_way_get_join DeleteSubServiceWayGet(Guid subServiceWayGetId)
        {
            spr_services_sub_way_get_join dbEntry = context.spr_services_sub_way_get_join.Find(subServiceWayGetId);
            if (dbEntry != null)
            {
                context.spr_services_sub_way_get_join.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        #endregion

        #region ////////////////////////////"Способ обращения за результатом услуги"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        /// <summary>
        /// сохраняет изменения записей
        /// </summary>
        /// <param name="subServiceWayGetResult">объект способа обращения за результатом услуги</param>
        public void SaveSubServiceWayGetResult(spr_services_sub_way_get_result_join subServiceWayGetResult)
        {
            context.spr_services_sub_way_get_result_join.Add(subServiceWayGetResult);
            context.SaveChanges();
        }

        /// <summary>
        /// удаляет запись по id
        /// </summary>
        /// <param name="subServiceWayGetResultId">id способа обращения за результатом услуги</param>
        /// <returns>возвращает какая запись была удалена</returns>
        public spr_services_sub_way_get_result_join DeleteSubServiceWayGetResult(Guid subServiceWayGetResultId)
        {
            spr_services_sub_way_get_result_join dbEntry = context.spr_services_sub_way_get_result_join.Find(subServiceWayGetResultId);
            if (dbEntry != null)
            {
                context.spr_services_sub_way_get_result_join.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        #endregion





        #region ////////////////////////////"Сервисы СМЭВ"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        /// <summary>
        /// сохраняет изменения записей
        /// </summary>
        /// <param name="smevService">объект сервиса</param>
        public void SaveSmevService(spr_smev smevService)
        {
            if (smevService.id == Guid.Empty)
            {
                context.spr_smev.Add(smevService);
            }
            else
            {
                spr_smev dbEntry = context.spr_smev.Find(smevService.id);
                if (dbEntry != null)
                {
                    dbEntry.provider_name = smevService.provider_name;
                    dbEntry.smev_name = smevService.smev_name;
                    dbEntry.smev_provider = smevService.smev_provider;
                    dbEntry.smev_mnemo = smevService.smev_mnemo;
                    dbEntry.smev_description = smevService.smev_description;
                    dbEntry.is_smev3 = smevService.is_smev3;
                    dbEntry.provider_code = smevService.provider_code;
                    dbEntry.provider_url = smevService.provider_url;
                    dbEntry.employees_fio_modifi = smevService.employees_fio_modifi;
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// удаляет запись по id
        /// </summary>
        /// <param name="smevServiceId">id сервиса</param>
        /// <returns>возвращает какая запись была удалена</returns>
        public spr_smev DeleteSmevService(Guid smevServiceId)
        {
            spr_smev dbEntry = context.spr_smev.Find(smevServiceId);
            if (dbEntry != null)
            {
                context.spr_smev.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        #endregion

        #region ////////////////////////////"Запросы СМЭВ"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        /// <summary>
        /// сохраняет изменения записей
        /// </summary>
        /// <param name="smevServiceRequest">объект запроса СМЭВ</param>
        public void SaveSmevServiceRequest(spr_smev_request smevServiceRequest)
        {
            if (smevServiceRequest.id == 0)
            {
                context.spr_smev_request.Add(smevServiceRequest);
            }
            else
            {
                spr_smev_request dbEntry = context.spr_smev_request.Find(smevServiceRequest.id);
                if (dbEntry != null)
                {
                    dbEntry.request_name = smevServiceRequest.request_name;
                    dbEntry.count_day_execution = smevServiceRequest.count_day_execution;
                    dbEntry.path = smevServiceRequest.path;
                    dbEntry.request_active = smevServiceRequest.request_active;
                    dbEntry.spr_smev_type_request = smevServiceRequest.spr_smev_type_request;
                    dbEntry.spr_services_sub_week_id = smevServiceRequest.spr_services_sub_week_id;
                    dbEntry.employees_fio_modifi = smevServiceRequest.employees_fio_modifi;
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// удаляет запись по id
        /// </summary>
        /// <param name="smevServiceRequestId">id запроса СМЭВ</param>
        /// <returns>возвращает какая запись была удалена</returns>
        public spr_smev_request DeleteSmevServiceRequest(Guid smevServiceRequestId)
        {
            spr_smev_request dbEntry = context.spr_smev_request.Find(smevServiceRequestId);
            if (dbEntry != null)
            {
                context.spr_smev_request.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        #endregion


        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Универсальные методы CRUD ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Создание универсального метода вставки
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            // Настройки контекста
            context.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));

            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }

        /// <summary>
        /// Запись нескольких полей в БД
        /// </summary>
        public void Inserts<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {

            // Отключаем отслеживание и проверку изменений для оптимизации вставки множества полей
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));


            foreach (TEntity entity in entities)
                context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();

            context.Configuration.AutoDetectChangesEnabled = true;
            context.Configuration.ValidateOnSaveEnabled = true;
        }

        /// <summary>
        /// Универсальный метод обновления
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void Update<TEntity>(TEntity entity)
            where TEntity : class
        {
            // Настройки контекста
            context.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));
            context.Entry(entity).State = EntityState.Modified;

            context.SaveChanges();
        }

        /// <summary>
        /// Универсальный метод удаления данных
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void Delete<TEntity>(TEntity entity)
            where TEntity : class
        {
            // Настройки контекста
            context.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));

            context.Entry<TEntity>(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }

        #endregion

        #region Kcr

        public IQueryable<Spr_Kcr> SprKcr => context.Spr_kcr;
        public IQueryable<Data_Kcr> DataKcr => context.Data_kcr;

        #endregion
    }
}

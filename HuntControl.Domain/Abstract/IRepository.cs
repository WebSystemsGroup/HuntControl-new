using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuntControl.Domain.Concrete;
using HuntControl.Domain.Models.Entities;

namespace HuntControl.Domain.Abstract
{
    public interface IRepository
    {
        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Таблицы  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|


        IQueryable<epgu_slot_time> EpguSlotTimes { get; }
        IQueryable<epgu_slot_time_book> EpguSlotTimeBooks { get; }

        IQueryable<data_employees_alert> DataEmployeeAlerts { get; }
        IQueryable<data_employees_reminder> DataEmployeeReminders { get; }

        IQueryable<data_change_log> DataChangeLogs { get; }
        IQueryable<data_calendar> DataCalendars { get; }
        IQueryable<data_calendar_day_type> DataCalendarDayTypes { get; }
        IQueryable<data_system_errors> DataSystemErrors { get; }

        IQueryable<data_services> DataServices { get; }
        IQueryable<data_services_document> DataServicesDocuments { get; }
        IQueryable<data_services_file> DataServicesFiles { get; }
        IQueryable<data_services_customer> DataServicesCustomers { get; }
        IQueryable<data_services_smev_request> DataServicesSmevRequests { get; }
        IQueryable<data_services_commentt> DataServicesComments { get; }
        IQueryable<data_services_commentt_recipient> DataServicesCommentsRecipients { get; }
        IQueryable<data_services_smev_request_status> DataServicesSmevRequestStatuses { get; }
        IQueryable<data_services_smev_log> DataServicesSmevLogs { get; }
        IQueryable<data_customer> DataCustomers { get; }
        IQueryable<data_customer_violations> DataCustomerViolations { get; }
        IQueryable<data_customer_violations_file> DataCustomerViolationsFile { get; }
        IQueryable<data_customer_hunting_lic> DataCustomerHuntingLics { get; }
        IQueryable<data_customer_hunting_lic_perm> DataCustomerHuntingLicPerms { get; }
        IQueryable<data_customer_hunting_lic_perm_hunting> DataCustomerHuntingLicPermHuntings { get; }
        IQueryable<data_customer_hunting_lic_perm_payment> DataCustomerHuntingLicPermPayments { get; }
        IQueryable<data_customer_hunting_lic_perm_animal> DataCustomerHuntingLicPermAnimals { get; }
        IQueryable<data_customer_hunting_lic_perm_back> DataCustomerHuntingLicPermBacks { get; }
        IQueryable<data_customer_hunting_lic_perm_back_animal> DataCustomerHuntingLicPermBackAnimals { get; }
        IQueryable<data_services_routes_stage> DataServicesRoutesStages { get; }


        IQueryable<spr_settings> SprSettings { get; }

        IQueryable<spr_account> SprAccounts { get; }
        IQueryable<spr_season> SprSeasons { get; }
        IQueryable<spr_season_open> SprSeasonOpens { get; }
        IQueryable<spr_season_animal> SprSeasonAnimals { get; }
        IQueryable<spr_season_open_animal> SprSeasonOpenAnimals { get; }


        IQueryable<spr_animal> SprAnimals { get; }
        IQueryable<spr_animal_group> SprAnimalGroups { get; }
        IQueryable<spr_animal_group_type> SprAnimalGroupTypes { get; }
        IQueryable<spr_animal_location> SprAnimalLocations { get; }
        IQueryable<spr_animal_hunting_type_join> SprAnimalHuntingTypeJoins { get; }
        IQueryable<spr_animal_method_account> SprAnimalMethodAccounts { get; }
        IQueryable<spr_bank> SprBanks { get; }
        IQueryable<spr_hunting_lic_status> SprHuntingLicStatus { get; }
        IQueryable<spr_hunting_farm> SprHuntingFarms { get; }
        IQueryable<spr_hunting_farm_location> SprHuntingFarmLocations { get; }
        IQueryable<spr_hunting_farm_season> SprHuntingFarmSeasons { get; }
        IQueryable<spr_hunting_farm_season_animal> SprHuntingFarmSeasonAnimals { get; }
        IQueryable<spr_hunting_farm_season_forms> SprHuntingFarmSeasonForms { get; }
        IQueryable<spr_hunting_farm_limit> SprHuntingFarmLimits { get; }
        IQueryable<spr_hunting_farm_accounting> SprHuntingFarmAccountings { get; }
        IQueryable<spr_hunting_farm_type> SprHuntingFarmTypes { get; }
        IQueryable<spr_hunting_farm_animal> SprHuntingFarmAnimals { get; }
        IQueryable<spr_hunting_type> SprHuntingTypes { get; }
        IQueryable<spr_method_remove> SprMethodRemoves { get; }
        IQueryable<spr_legal_person> SprLegalPersons { get; }

        IQueryable<spr_employees> SprEmployees { get; }
        IQueryable<spr_employees_job_pos> SprEmployeesJobPos { get; }
        IQueryable<spr_employees_role> SprEmployeesRoles { get; }
        IQueryable<spr_employees_role_join> SprEmployeesRoleJoins { get; }
        IQueryable<spr_employees_department> SprEmployeesDepartments { get; }
        IQueryable<spr_employees_hunting_farm> SprEmployeesHuntingFarms { get; }

        IQueryable<spr_documents> SprDocuments { get; }
        IQueryable<spr_document_identity> SprDocumentIdentities { get; }

        IQueryable<spr_routes_stage> SprRoutesStages { get; }
        IQueryable<spr_definition_type> SprDefinitionTypes { get; }
        IQueryable<spr_taxation> SprTaxations { get; }

        IQueryable<spr_bailiffs> SprBailiffs { get; }
        IQueryable<spr_organization> SprOrganizations { get; }
        IQueryable<spr_violations_status> SprViolationsStatus { get; }
        IQueryable<spr_violations_document> SprViolationsDocument { get; }
        IQueryable<spr_bailiffs_result> SprBailiffsResult { get; }
        IQueryable<spr_organization_result> SprOrganizationsResult { get; }



        #region ////////////////////////////"Сервисы СМЭВ"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        IQueryable<spr_smev> SprSmevServices { get; }
        IQueryable<spr_smev_request> SprSmevRequests { get; }
        IQueryable<spr_smev_type_request> SprSmevRequestTypes { get; }

        #endregion


        #region ////////////////////////////"Услуги"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        IQueryable<spr_services> SprServices { get; }
        IQueryable<spr_services_type> SprServicesTypes { get; }
        IQueryable<spr_services_sub> SprServicesSubs { get; }
        IQueryable<spr_services_sub_status> SprServicesSubStatuses { get; }
        IQueryable<spr_services_sub_active> SprServicesSubActives { get; }
        IQueryable<spr_services_sub_result_doc> SprServicesSubResultDocs { get; }
        IQueryable<spr_services_sub_customer> SprServicesSubCustomers { get; }
        IQueryable<spr_services_sub_document> SprServicesSubDocuments { get; }
        IQueryable<spr_services_sub_document_customer> SprServicesSubDocumentCustomers { get; }
        IQueryable<spr_services_sub_failure> SprServicesSubFailures { get; }
        IQueryable<spr_services_sub_failure_doc> SprServicesSubFailureDocs { get; }
        IQueryable<spr_services_sub_tariff> SprServicesSubTariffs { get; }
        IQueryable<spr_services_sub_tariff_type> SprServicesSubTariffTypes { get; }
        IQueryable<spr_services_sub_type_recipient> SprServicesSubTypeRecipients { get; }
        IQueryable<spr_services_sub_type_quality> SprServicesSubTypeQualities { get; }
        IQueryable<spr_services_sub_type_quality_join> SprServicesSubTypeQualityJoins { get; }
        IQueryable<spr_services_sub_way_get> SprServicesSubWayGets { get; }
        IQueryable<spr_services_sub_way_get_join> SprServicesSubWayGetJoins { get; }
        IQueryable<spr_services_sub_way_get_result> SprServicesSubWayGetResults { get; }
        IQueryable<spr_services_sub_way_get_result_join> SprServicesSubWayGetResultJoins { get; }
        IQueryable<spr_services_sub_file_folder> SprServicesSubFileFolders { get; }
        IQueryable<spr_services_sub_file> SprServicesSubFiles { get; }
        IQueryable<spr_services_sub_week> SprServicesSubWeeks { get; }
        IQueryable<spr_services_sub_smev_request_join> SprServicesSubSmevRequests { get; }
        IQueryable<spr_violations> SprViolations { get; }
        IQueryable<spr_violations_part> SprViolationsPart { get; }

        #endregion


        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Функции  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        StatementInfoGetResult FuncStatementInfoGet(string infoId);
        IEnumerable<EpguVisitTimeSelectResult> FuncEpguVisitTimeSelect();
        IEnumerable<StatementDocumentSelectResult> FuncStatementDocumentSelect(Guid serviceId);
        IEnumerable<DataCustomerInfoGet> FuncDataCustomerInfoGet(Guid customerId);
        IEnumerable<HuntingBackAnimalSelectResult> FuncHuntingBackAnimalSelect(Guid huntingLicPermId);
        IEnumerable<CustomerSelectResult> FuncCustomerSelect(Guid customerId, string search);
        IEnumerable<CustomerHuntingLicenseSelectResult> FuncCustomerHuntingLicenseSelect(Guid customerId);
        HuntingCustomerInfoGetResultDto FuncHuntingCustomerInfoGetDto(Guid customerId);
        IEnumerable<HuntingFarmActiveSeasonSelectResult> FuncHuntingFarmActiveSeasonSelect(string employeeLogin);
        IEnumerable<HuntingFarmActiveGroupTypeSelectResult> FuncHuntingFarmActiveGroupTypeSelect(Guid huntingFarmId);
        IEnumerable<HuntingFarmActiveHuntingTypeSelectResult> FuncHuntingFarmActiveHuntingTypeSelect(Guid huntingFarmSeasonId);
        IEnumerable<HuntingFarmSeasonAnimalSelectResult> FuncHuntingFarmSeasonAnimalSelect(Guid huntingFarmId, Guid animalGroupTypeId);
        IEnumerable<HuntingLimitAnimalSelectResult> FuncHuntingLimitAnimalSelect(Guid huntingFarmSeasonId, Guid huntingTypeId);
        IEnumerable<HuntingLimitFormsGetResult> FuncHuntingLimitFormsGet(Guid huntingFarmSeasonId);
        IEnumerable<AlertEmployeeSelectResult> FuncAlertEmployeeSelect(Guid employeeId);
        IEnumerable<CaseServicesDocumentSelectResult> FuncCaseServicesDocumentSelect(Guid serviceId);
        IEnumerable<CaseServicesFileSelectResult> FuncCaseServicesFileSelect(string infoId);
        IEnumerable<CaseServicesSmevSelectResult> FuncCaseServicesSmevSelect(Guid serviceId, Guid employeeId);
        IEnumerable<CaseServicesSmevRequestSelectResult> FuncCaseServicesSmevRequestSelect(Guid serviceId);
        IEnumerable<CaseServicesDocumentFileSelectResult> FuncCaseServicesDocumentFileSelect(Guid documentId);
        IEnumerable<CaseServicesRoutesStageSelectResult> FuncCaseServicesRoutesStageSelect(Guid serviceId, Guid employeeId);
        IEnumerable<CaseServicesRoutesStageNextSelectResult> FuncCaseServicesRoutesStageNextSelect(Guid serviceId, Guid employeeId);
        CaseServicesInfoGetResult FuncCaseServicesInfoGet(string infoId);
        IEnumerable<CaseSelectResult> FuncCaseSelect(Guid employeeId, DateTime startDate, DateTime stopDate, Guid? serviceSubId, short? serviceSubStatusId, Guid? servicesSubWayGetId);

        IEnumerable<CaseSelectResult> FuncCaseArchiveSelect(Guid employeeId, Guid in_spr_employees_id_execution, DateTime startDate, DateTime stopDate, Guid? serviceSubId, short? serviceSubStatusId, Guid? servicesSubWayGetId);


        GetCustomerInfoResult FuncGetCustomerInfo(string customerDocSerial, string customerDocNumber);
        IEnumerable<SprServicesSubSelectResult> FuncSprServicesSubSelect();
        IEnumerable<SprServicesSubCustomerTypeRecipientSelect> FuncSprServicesSubCustomerTypeRecipientSelect(Guid servicesSubId);
        IEnumerable<SprServicesSubTariffSelectResult> FuncSprServicesSubTariffSelect(Guid sprServicesSubId, int recipient);
        HuntingLicPermsResult FuncGetHuntingLicPermsResult(Guid dataCustomerHuntingLicPermId);
        IEnumerable<ViolationSelectResult> FuncViolationSelect(Guid? employeeId, DateTime startDate, DateTime stopDate, int? statusId, int? documentId);
        IEnumerable<ViolationsCustomerSelectResult> FuncViolationsCustomerSelect(Guid? employeeId, DateTime startDate, DateTime stopDate, int? statusId, int? documentId, Guid? sprViolationId);
        IEnumerable<CustomerViolationsSelectResult> FuncCustomerViolationsSelect(Guid dataCustomerId);

        #region  исправить названия
        IEnumerable<CustomerHuntingSeason> FuncGetCustomerHuntingSeason(int spr_season_id, int year);
        #endregion





        IEnumerable<ReportHuntingLicIssuedReestrResult> FuncReportHuntingLicIssuedReestr(DateTime dateStart, DateTime dateStop);
        IEnumerable<ReportHuntingLicIssuedReestrResult> FuncReportHuntingLicIssuedNumberReestr(int numberStart, int numberStop);
        IEnumerable<ReportHuntingLicCancelledReestrResult> FuncReportHuntingLicCancelledReestr(DateTime dateStart, DateTime dateStop);
        IEnumerable<ReportReestrCountServiceResult> FuncReportReestrCountService(DateTime dateStart, DateTime dateStop, int subServiceStatusId, Guid subServiceWayGetId);
        IEnumerable<ReportDataCustomerViolationsReestrResult> FuncReportReestrDataCustomerViolations(DateTime dateStart, DateTime dateStop, Guid? sprEmployeesId, Guid? sprEmployeesDepartmentId, Guid? sprViolationsId);
        IEnumerable<ReportHuntingLicNotPermBackResult> FuncReportHuntingLicNotPermBackReestr(DateTime dateStart, DateTime dateStop, Guid IdGroupType, Guid IdAnimals, Guid IdHuntingFarm);
        IEnumerable<ReportHuntingLicPermResult> FuncReportHuntingLicPerm(int? sprSeasonId, Guid? animalId, DateTime startDate, DateTime stopDate, Guid? sprHuntingFarmId);
        IEnumerable<ReportCountViolationsHuntingFarm> FuncReportCountViolationsHuntingFarm(DateTime startDate, DateTime stopDate, Guid? sprEmployeesId, Guid? sprEmployeesDepartmentId, Guid? sprViolationsId);
        IEnumerable<ReportCountViolationsEmployees> FuncReportCountViolationsEmployees(DateTime startDate, DateTime stopDate, Guid? sprViolationsId);
        IEnumerable<ReportCountViolations> FuncReportCountViolations(DateTime startDate, DateTime stopDate, Guid? sprEmployeesDepartmentId, Guid? sprViolationsId);
        IEnumerable<ReportTotalHuntingFarmResult> FuncReportTotalHuntingFarm(Guid? huntingFarmTypeId, Guid? animalGroupTypeId, Guid? animalId, DateTime startDate, DateTime stopDate);
        IEnumerable<ReportTotalHuntingGroupResult> FuncReportTotalHuntingGroup(Guid? huntingFarmId, Guid? huntingFarmTypeId, DateTime startDate, DateTime stopDate); 
        FormUngulateInfoResult FuncFormUngulateInfo(Guid huntingLicPermId);
        FormBearInfoResult FuncFormBearInfo(Guid huntingLicPermId);
        FormBirdInfoResult FuncFormBirdInfo(Guid huntingLicPermId);
        FormFurInfoResult FuncFormFurInfo(Guid huntingLicPermId);
        IEnumerable<FormAnimalSelectResult> FuncFormAnimalSelect(Guid huntingLicPermId);
        IEnumerable<SeasonHuntingFarmAccountingResult> FuncSeasonHuntingFarmAccountingSelect(Guid animalId, short animalSex, short animalAge, short year);
        IEnumerable<MainCountEpguAndMfcResult> FuncMainCountEpguAndMfcSelect(int year);
        IEnumerable<MainCountHuntingFarmResult> FuncMainCountHuntingFarmSelect(int year);
        IEnumerable<MainCountIssueAndCancelledHuntingLicResult> FuncMainCountIssueAndCancelledHuntingLicSelect(int year);
        IEnumerable<MainCountIssueGroupTypeResult> FuncMainCountIssueGroupTypeSelect(int year);
        IEnumerable<MainCountViolationsResult> FuncMainCountViolationsSelect(int year);
        MainGeneralInformationResult FuncMainGeneralInformationSelect();


        FtpSettings FuncGetFtpSettings();

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Методы CRUD таблиц  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|


        void SaveDataService(data_services service);
        data_services DeleteDataService(Guid serviceId);

        void SaveDataServiceCustomer(data_services_customer serviceCustomer);
        data_services_customer DeleteDataServiceCustomer(Guid serviceCustomerId);


        void SaveCustomer(data_customer customer);
        data_customer DeleteCustomer(Guid customerId);

        void SaveHuntingFarmType(spr_hunting_farm_type huntingFarmType);
        spr_hunting_farm_type DeleteHuntingFarmType(Guid huntingFarmTypeId);




        ///////////////////////////////// Справочники  ///////////////////////////////////////

        #region ////////////////////////////"Услуги"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


        void SaveSubServiceWayGet(spr_services_sub_way_get_join subServiceWayGet);
        spr_services_sub_way_get_join DeleteSubServiceWayGet(Guid subServiceWayGetId);

        void SaveSubServiceWayGetResult(spr_services_sub_way_get_result_join subServiceWayGetResult);
        spr_services_sub_way_get_result_join DeleteSubServiceWayGetResult(Guid subServiceWayGetResultId);

        void SaveSubServiceFailure(spr_services_sub_failure subServiceFailure);
        spr_services_sub_failure DeleteSubServiceFailure(Guid subServiceFailureId);

        void SaveSubServiceFailureDoc(spr_services_sub_failure_doc subServiceFailureDoc);
        spr_services_sub_failure_doc DeleteSubServiceFailureDoc(Guid subServiceFailureDocId);

        void SaveSubServiceResultDoc(spr_services_sub_result_doc subServiceResultDoc);
        spr_services_sub_result_doc DeleteSubServiceResultDoc(Guid subServiceResultDocId);

        void SaveSubServiceCustomer(spr_services_sub_customer subServiceCustomer);
        spr_services_sub_customer DeleteSubServiceCustomer(Guid subServiceCustomerId);

        void SaveSubServiceDocument(spr_services_sub_document subServiceDocument);
        spr_services_sub_document DeleteSubServiceDocument(Guid subServiceDocumentId);

        void SaveSubServiceCustomerTariff(spr_services_sub_tariff customerTariff);
        spr_services_sub_tariff DeleteSubServiceCustomerTariff(Guid customerTariffId);

        void SaveSubServiceCustomerDocument(spr_services_sub_document_customer customerDocument);
        spr_services_sub_document_customer DeleteSubServiceCustomerDocument(Guid customerDocumentId);

        #endregion


        #region ////////////////////////////"Сервисы СМЭВ"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        void SaveSmevService(spr_smev smevService);
        spr_smev DeleteSmevService(Guid smevServiceId);

        void SaveSmevServiceRequest(spr_smev_request smevServiceRequest);
        spr_smev_request DeleteSmevServiceRequest(Guid smevServiceRequestId);

        #endregion

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Универсальные методы CRUD  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        void Insert<TEntity>(TEntity entity) where TEntity : class;
        void Inserts<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;

        #endregion

        #region Kcr

        IQueryable<Spr_Kcr> SprKcr { get; }
        IQueryable<Data_Kcr> DataKcr { get; }

        #endregion
    }
}

namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using HuntControl.Domain.Models.Entities;

    public partial class EFDbContext : DbContext
    {
        public EFDbContext() : base("name=EFDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<data_calendar> data_calendar { get; set; }
        public virtual DbSet<data_calendar_day_type> data_calendar_day_type { get; set; }
        public virtual DbSet<data_employees_alert> data_employees_alert { get; set; }
        public virtual DbSet<data_employees_reminder> data_employees_reminder { get; set; }
        public virtual DbSet<data_change_log> data_change_log { get; set; }
        public virtual DbSet<data_services> data_services { get; set; }
        public virtual DbSet<data_services_commentt> data_services_commentt { get; set; }
        public virtual DbSet<data_services_commentt_recipient> data_services_commentt_recipient { get; set; }
        public virtual DbSet<data_services_customer> data_services_customer { get; set; }
        public virtual DbSet<data_services_customer_call> data_services_customer_call { get; set; }
        public virtual DbSet<data_services_customer_message> data_services_customer_message { get; set; }
        public virtual DbSet<data_services_document> data_services_document { get; set; }
        public virtual DbSet<data_services_file> data_services_file { get; set; }
        public virtual DbSet<data_services_routes_stage> data_services_routes_stage { get; set; }
        public virtual DbSet<data_services_smev_log> data_services_smev_log { get; set; }
        public virtual DbSet<data_services_smev_request> data_services_smev_request { get; set; }
        public virtual DbSet<data_services_smev_request_status> data_services_smev_request_status { get; set; }
        public virtual DbSet<data_services_view_log> data_services_view_log { get; set; }
        public virtual DbSet<data_system_errors> data_system_errors { get; set; }
        public virtual DbSet<spr_alert> spr_alert { get; set; }
        public virtual DbSet<spr_employee_alert> spr_employee_alert { get; set; }
        public virtual DbSet<spr_employees_job_pos> spr_employees_job_pos { get; set; }
        public virtual DbSet<spr_routes_stage> spr_routes_stage { get; set; }
        public virtual DbSet<spr_routes_stage_next> spr_routes_stage_next { get; set; }
        public virtual DbSet<spr_settings> spr_settings { get; set; }

        public virtual DbSet<epgu_slot_time> epgu_slot_time { get; set; }
        public virtual DbSet<epgu_slot_time_book> epgu_slot_time_book { get; set; }

        public virtual DbSet<data_customer> data_customer { get; set; }
        public virtual DbSet<data_customer_hunting_lic> data_customer_hunting_lic { get; set; }
        public virtual DbSet<data_customer_hunting_lic_perm> data_customer_hunting_lic_perm { get; set; }
        public virtual DbSet<data_customer_hunting_lic_perm_hunting> data_customer_hunting_lic_perm_hunting { get; set; }
        public virtual DbSet<data_customer_hunting_lic_perm_animal> data_customer_hunting_lic_perm_animal { get; set; }
        public virtual DbSet<data_customer_hunting_lic_perm_back> data_customer_hunting_lic_perm_back { get; set; }
        public virtual DbSet<data_customer_hunting_lic_perm_back_animal> data_customer_hunting_lic_perm_back_animal { get; set; }
        public virtual DbSet<data_customer_hunting_lic_perm_payment> data_customer_hunting_lic_perm_payment { get; set; }
        public virtual DbSet<data_customer_violations> data_customer_violations { get; set; }
        public virtual DbSet<data_customer_violations_file> data_customer_violations_file { get; set; }

        public virtual DbSet<spr_account> spr_account { get; set; }
        public virtual DbSet<spr_animal> spr_animal { get; set; }
        public virtual DbSet<spr_animal_group> spr_animal_group { get; set; }
        public virtual DbSet<spr_animal_group_type> spr_animal_group_type { get; set; }
        public virtual DbSet<spr_animal_location> spr_animal_location { get; set; }
        public virtual DbSet<spr_animal_hunting_type_join> spr_animal_hunting_type_join { get; set; }
        public virtual DbSet<spr_animal_method_account> spr_animal_method_account { get; set; }
        public virtual DbSet<spr_bank> spr_bank { get; set; }
        public virtual DbSet<spr_documents> spr_documents { get; set; }
        public virtual DbSet<spr_document_identity> spr_document_identity { get; set; }
        public virtual DbSet<spr_employees> spr_employees { get; set; }
        public virtual DbSet<spr_employees_hunting_farm> spr_employees_hunting_farm { get; set; }
        public virtual DbSet<spr_employees_department> spr_employees_department { get; set; }
        public virtual DbSet<spr_employees_role> spr_employees_role { get; set; }
        public virtual DbSet<spr_employees_role_join> spr_employees_role_join { get; set; }
        public virtual DbSet<spr_hunting_farm> spr_hunting_farm { get; set; }
        public virtual DbSet<spr_hunting_farm_location> spr_hunting_farm_location { get; set; }
        public virtual DbSet<spr_hunting_farm_season> spr_hunting_farm_season { get; set; }
        public virtual DbSet<spr_hunting_farm_season_animal> spr_hunting_farm_season_animal { get; set; }
        public virtual DbSet<spr_hunting_farm_season_forms> spr_hunting_farm_season_forms { get; set; }
        public virtual DbSet<spr_hunting_farm_accounting> spr_hunting_farm_accounting { get; set; }
        public virtual DbSet<spr_hunting_farm_animal> spr_hunting_farm_animal { get; set; }
        public virtual DbSet<spr_hunting_farm_limit> spr_hunting_farm_limit { get; set; }
        public virtual DbSet<spr_hunting_farm_type> spr_hunting_farm_type { get; set; }
        public virtual DbSet<spr_hunting_lic_status> spr_hunting_lic_status { get; set; }
        public virtual DbSet<spr_hunting_type> spr_hunting_type { get; set; }
        public virtual DbSet<spr_method_remove> spr_method_remove { get; set; }
        public virtual DbSet<spr_legal_person> spr_legal_person { get; set; }
        public virtual DbSet<spr_season> spr_season { get; set; }
        public virtual DbSet<spr_season_open> spr_season_open { get; set; }
        public virtual DbSet<spr_season_animal> spr_season_animal { get; set; }
        public virtual DbSet<spr_season_open_animal> spr_season_open_animal { get; set; }
        public virtual DbSet<spr_services> spr_services { get; set; }
        public virtual DbSet<spr_services_sub> spr_services_sub { get; set; }
        public virtual DbSet<spr_services_sub_active> spr_services_sub_active { get; set; }
        public virtual DbSet<spr_services_sub_customer> spr_services_sub_customer { get; set; }
        public virtual DbSet<spr_services_sub_document> spr_services_sub_document { get; set; }
        public virtual DbSet<spr_services_sub_document_customer> spr_services_sub_document_customer { get; set; }
        public virtual DbSet<spr_services_sub_failure> spr_services_sub_failure { get; set; }
        public virtual DbSet<spr_services_sub_failure_doc> spr_services_sub_failure_doc { get; set; }
        public virtual DbSet<spr_services_sub_file> spr_services_sub_file { get; set; }
        public virtual DbSet<spr_services_sub_file_folder> spr_services_sub_file_folder { get; set; }
        public virtual DbSet<spr_services_sub_result_doc> spr_services_sub_result_doc { get; set; }
        public virtual DbSet<spr_services_sub_smev_request_join> spr_services_sub_smev_request_join { get; set; }
        public virtual DbSet<spr_services_sub_status> spr_services_sub_status { get; set; }
        public virtual DbSet<spr_services_sub_stop> spr_services_sub_stop { get; set; }
        public virtual DbSet<spr_services_sub_tariff> spr_services_sub_tariff { get; set; }
        public virtual DbSet<spr_services_sub_tariff_type> spr_services_sub_tariff_type { get; set; }
        public virtual DbSet<spr_services_sub_type_quality> spr_services_sub_type_quality { get; set; }
        public virtual DbSet<spr_services_sub_type_quality_join> spr_services_sub_type_quality_join { get; set; }
        public virtual DbSet<spr_services_sub_type_recipient> spr_services_sub_type_recipient { get; set; }
        public virtual DbSet<spr_services_sub_way_get> spr_services_sub_way_get { get; set; }
        public virtual DbSet<spr_services_sub_way_get_join> spr_services_sub_way_get_join { get; set; }
        public virtual DbSet<spr_services_sub_way_get_result> spr_services_sub_way_get_result { get; set; }
        public virtual DbSet<spr_services_sub_way_get_result_join> spr_services_sub_way_get_result_join { get; set; }
        public virtual DbSet<spr_services_sub_week> spr_services_sub_week { get; set; }
        public virtual DbSet<spr_services_type> spr_services_type { get; set; }
        public virtual DbSet<spr_smev> spr_smev { get; set; }
        public virtual DbSet<spr_smev_request> spr_smev_request { get; set; }
        public virtual DbSet<spr_smev_type_request> spr_smev_type_request { get; set; }
        public virtual DbSet<spr_standards_file> spr_standards_file { get; set; }
        public virtual DbSet<spr_violations> spr_violations { get; set; }
        public virtual DbSet<spr_violations_part> spr_violations_part { get; set; }
        public virtual DbSet<spr_violations_status> spr_violations_status { get; set; }
        public virtual DbSet<spr_violations_document> spr_violations_document { get; set; }
        public virtual DbSet<spr_definition_type> spr_definition_type { get; set; }
        public virtual DbSet<spr_taxation> spr_taxation { get; set; }

        public virtual DbSet<spr_bailiffs> spr_bailiffs { get; set; }
        public virtual DbSet<spr_organization> spr_organization { get; set; }
        public virtual DbSet<spr_bailiffs_result> spr_bailiffs_result { get; set; }
        public virtual DbSet<spr_organization_result> spr_organization_result { get; set; }

        public DbSet<Spr_Kcr> Spr_kcr { get; set; }
        public DbSet<Data_Kcr> Data_kcr { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<spr_employees>()
                .HasMany(e => e.spr_employees_hunting_farm)
                .WithRequired(e => e.spr_employees)
                .HasForeignKey(e => e.spr_employees_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_hunting_farm>()
                .Property(e => e.hunting_farm_area)
                .HasPrecision(15, 2);

            modelBuilder.Entity<spr_hunting_farm>()
                .HasMany(e => e.spr_employees_hunting_farm)
                .WithRequired(e => e.spr_hunting_farm)
                .HasForeignKey(e => e.spr_hunting_farm_id);

            modelBuilder.Entity<data_customer_violations>()
                .Property(e => e.res_amount_fine)
                .HasPrecision(15, 2);

            modelBuilder.Entity<spr_hunting_farm_accounting>()
                .HasMany(e => e.spr_hunting_farm_limit)
                .WithRequired(e => e.spr_hunting_farm_accounting)
                .HasForeignKey(e => e.spr_hunting_farm_accounting_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_hunting_farm>()
                .HasMany(e => e.spr_hunting_farm_accounting)
                .WithRequired(e => e.spr_hunting_farm)
                .HasForeignKey(e => e.spr_hunting_farm_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_animal>()
                .HasMany(e => e.spr_hunting_farm_accounting)
                .WithRequired(e => e.spr_animal)
                .HasForeignKey(e => e.spr_animal_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_animal_method_account>()
                .HasMany(e => e.spr_hunting_farm_accounting)
                .WithRequired(e => e.spr_animal_method_account)
                .HasForeignKey(e => e.spr_animal_method_account_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_animal>()
                .HasMany(e => e.spr_hunting_farm_season_animal)
                .WithRequired(e => e.spr_animal)
                .HasForeignKey(e => e.spr_animal_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_hunting_farm_season>()
                .HasMany(e => e.spr_hunting_farm_season_animal)
                .WithRequired(e => e.spr_hunting_farm_season)
                .HasForeignKey(e => e.spr_hunting_farm_season_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_hunting_farm>()
                .HasMany(e => e.data_customer_hunting_lic_perm)
                .WithRequired(e => e.spr_hunting_farm)
                .HasForeignKey(e => e.spr_hunting_farm_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_animal_group_type>()
                .HasMany(e => e.spr_animal)
                .WithRequired(e => e.spr_animal_group_type)
                .HasForeignKey(e => e.spr_animal_group_type_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_animal>()
                .HasMany(e => e.spr_animal_hunting_type_join)
                .WithRequired(e => e.spr_animal)
                .HasForeignKey(e => e.spr_animal_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_animal_group>()
                .HasMany(e => e.spr_animal_group_type)
                .WithRequired(e => e.spr_animal_group)
                .HasForeignKey(e => e.spr_animal_group_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_animal>()
                .HasMany(e => e.spr_animal_location)
                .WithRequired(e => e.spr_animal)
                .HasForeignKey(e => e.spr_animal_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_hunting_type>()
                .HasMany(e => e.spr_animal_hunting_type_join)
                .WithRequired(e => e.spr_hunting_type)
                .HasForeignKey(e => e.spr_hunting_type_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_animal>()
                .HasMany(e => e.data_customer_hunting_lic_perm_animal)
                .WithRequired(e => e.spr_animal)
                .HasForeignKey(e => e.spr_animal_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<data_customer_hunting_lic_perm>()
                .HasMany(e => e.data_customer_hunting_lic_perm_animal)
                .WithRequired(e => e.data_customer_hunting_lic_perm)
                .HasForeignKey(e => e.data_customer_hunting_lic_perm_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<data_customer_hunting_lic_perm>()
                .HasMany(e => e.data_customer_hunting_lic_perm_hunting)
                .WithRequired(e => e.data_customer_hunting_lic_perm)
                .HasForeignKey(e => e.data_customer_hunting_lic_perm_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<data_customer_hunting_lic_perm_back>()
                .HasMany(e => e.data_customer_hunting_lic_perm_back_animal)
                .WithRequired(e => e.data_customer_hunting_lic_perm_back)
                .HasForeignKey(e => e.data_customer_hunting_lic_perm_back_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_animal>()
                .HasMany(e => e.data_customer_hunting_lic_perm_back_animal)
                .WithRequired(e => e.spr_animal)
                .HasForeignKey(e => e.spr_animal_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_hunting_farm>()
                .HasMany(e => e.spr_hunting_farm_location)
                .WithRequired(e => e.spr_hunting_farm)
                .HasForeignKey(e => e.spr_hunting_farm_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_hunting_farm>()
                .HasMany(e => e.data_customer_hunting_lic_perm_hunting)
                .WithRequired(e => e.spr_hunting_farm)
                .HasForeignKey(e => e.spr_hunting_farm_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_season>()
                .HasMany(e => e.data_customer_hunting_lic_perm)
                .WithOptional(e => e.spr_season)
                .HasForeignKey(e => e.spr_season_id)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<spr_animal_group_type>()
            //    .HasMany(e => e.data_customer_hunting_lic_perm)
            //    .WithRequired(e => e.spr_animal_group_type)
            //    .HasForeignKey(e => e.spr_animal_group_type_id)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub_type_recipient>()
                .HasMany(e => e.spr_legal_person)
                .WithOptional(e => e.spr_services_sub_type_recipient)
                .HasForeignKey(e => e.spr_services_sub_type_recipient_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_bailiffs>()
                .HasMany(e => e.data_customer_violations)
                .WithOptional(e => e.spr_bailiffs)
                .HasForeignKey(e => e.bai_spr_bailiffs_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_organization>()
                .HasMany(e => e.data_customer_violations)
                .WithOptional(e => e.spr_organization)
                .HasForeignKey(e => e.tr_spr_organization_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<data_calendar_day_type>()
                .HasMany(e => e.data_calendar)
                .WithRequired(e => e.data_calendar_day_type)
                .HasForeignKey(e => e.date_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<data_customer>()
                .HasMany(e => e.data_customer_hunting_lic)
                .WithRequired(e => e.data_customer)
                .HasForeignKey(e => e.data_customer_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<data_customer>()
                .HasMany(e => e.data_customer_violations)
                .WithRequired(e => e.data_customer)
                .HasForeignKey(e => e.data_customer_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<data_customer_hunting_lic>()
                .HasMany(e => e.data_customer_hunting_lic_perm)
                .WithRequired(e => e.data_customer_hunting_lic)
                .HasForeignKey(e => e.data_customer_hunting_lic_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<data_customer_hunting_lic_perm>()
                .HasMany(e => e.data_customer_hunting_lic_perm_back)
                .WithRequired(e => e.data_customer_hunting_lic_perm)
                .HasForeignKey(e => e.data_customer_hunting_lic_perm_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<data_services>()
                .Property(e => e.tariff_state)
                .HasPrecision(15, 2);

            modelBuilder.Entity<data_services>()
                .HasMany(e => e.data_employees_alert)
                .WithOptional(e => e.data_services)
                .HasForeignKey(e => e.data_services_id);

            modelBuilder.Entity<data_services>()
                .HasMany(e => e.data_services_commentt)
                .WithRequired(e => e.data_services)
                .HasForeignKey(e => e.data_services_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<data_services>()
                .HasMany(e => e.data_services_customer_call)
                .WithRequired(e => e.data_services)
                .HasForeignKey(e => e.data_services_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<data_services>()
                .HasMany(e => e.data_services_customer)
                .WithRequired(e => e.data_services)
                .HasForeignKey(e => e.data_services_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<data_services>()
                .HasMany(e => e.data_services_customer_message)
                .WithRequired(e => e.data_services)
                .HasForeignKey(e => e.data_services_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<data_services>()
                .HasMany(e => e.data_services_document)
                .WithRequired(e => e.data_services)
                .HasForeignKey(e => e.data_services_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<data_services>()
                .HasMany(e => e.data_services_routes_stage)
                .WithRequired(e => e.data_services)
                .HasForeignKey(e => e.data_services_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<data_services_smev_request>()
                .HasMany(e => e.data_services_smev_log)
                .WithOptional(e => e.data_services_smev_request)
                .HasForeignKey(e => e.data_services_smev_request_id);

            modelBuilder.Entity<data_services_smev_request>()
                .HasMany(e => e.data_services_smev_request_status)
                .WithRequired(e => e.data_services_smev_request)
                .HasForeignKey(e => e.data_services_smev_request_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_employee_alert>()
                .HasMany(e => e.data_employees_alert)
                .WithRequired(e => e.spr_employee_alert)
                .HasForeignKey(e => e.spr_employee_alert_id)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<spr_animal_group_type>()
            //    .HasMany(e => e.spr_hunting_farm_season)
            //    .WithRequired(e => e.spr_animal_group_type)
            //    .HasForeignKey(e => e.spr_animal_group_type_id)
                //.WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_season>()
                .HasMany(e => e.spr_hunting_farm_season)
                .WithRequired(e => e.spr_season)
                .HasForeignKey(e => e.spr_season_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_season>()
                .HasMany(e => e.spr_season_open)
                .WithRequired(e => e.spr_season)
                .HasForeignKey(e => e.spr_season_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_season_open>()
                .HasMany(e => e.spr_season_open_animal)
                .WithRequired(e => e.spr_season_open)
                .HasForeignKey(e => e.spr_season_open_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_animal>()
                .HasMany(e => e.spr_season_open_animal)
                .WithRequired(e => e.spr_animal)
                .HasForeignKey(e => e.spr_animal_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_animal>()
                .HasMany(e => e.spr_hunting_farm_animal)
                .WithRequired(e => e.spr_animal)
                .HasForeignKey(e => e.spr_animal_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_bank>()
                .HasMany(e => e.spr_legal_person)
                .WithRequired(e => e.spr_bank)
                .HasForeignKey(e => e.spr_bank_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_documents>()
                .HasMany(e => e.data_services_document)
                .WithRequired(e => e.spr_documents)
                .HasForeignKey(e => e.spr_documents_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_documents>()
                .HasMany(e => e.spr_services_sub_document_customer)
                .WithRequired(e => e.spr_documents)
                .HasForeignKey(e => e.spr_documents_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_documents>()
                .HasMany(e => e.spr_services_sub_document)
                .WithRequired(e => e.spr_documents)
                .HasForeignKey(e => e.spr_documents_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_documents>()
                .HasMany(e => e.spr_services_sub_result_doc)
                .WithRequired(e => e.spr_documents)
                .HasForeignKey(e => e.spr_documents_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_employees_job_pos>()
                .HasMany(e => e.spr_employees)
                .WithRequired(e => e.spr_employees_job_pos)
                .HasForeignKey(e => e.spr_employees_job_pos_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_employees>()
                .HasMany(e => e.data_system_errors)
                .WithRequired(e => e.spr_employees)
                .HasForeignKey(e => e.spr_employees_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_employees>()
                .HasMany(e => e.data_employees_alert)
                .WithRequired(e => e.spr_employees)
                .HasForeignKey(e => e.spr_employees_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_employees>()
                .HasMany(e => e.data_services_execution)
                .WithOptional(e => e.spr_employees_execution)
                .HasForeignKey(e => e.spr_employees_id_execution);

            modelBuilder.Entity<spr_employees>()
                .HasMany(e => e.data_services)
                .WithRequired(e => e.spr_employees)
                .HasForeignKey(e => e.spr_employees_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_employees>()
                .HasMany(e => e.data_services_commentt)
                .WithRequired(e => e.spr_employees)
                .HasForeignKey(e => e.spr_employees_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_employees>()
                .HasMany(e => e.data_services_customer)
                .WithOptional(e => e.spr_employees)
                .HasForeignKey(e => e.spr_employees_id);

            modelBuilder.Entity<spr_employees>()
                .HasMany(e => e.data_services_customer_call)
                .WithRequired(e => e.spr_employees)
                .HasForeignKey(e => e.spr_employees_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_employees>()
                .HasMany(e => e.data_services_customer_message)
                .WithRequired(e => e.spr_employees)
                .HasForeignKey(e => e.spr_employees_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_employees>()
                .HasMany(e => e.data_services_file)
                .WithRequired(e => e.spr_employees)
                .HasForeignKey(e => e.spr_employees_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_employees>()
                .HasMany(e => e.data_services_routes_stage)
                .WithRequired(e => e.spr_employees)
                .HasForeignKey(e => e.spr_employees_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_employees>()
                .HasMany(e => e.data_services_routes_stage_fact)
                .WithRequired(e => e.spr_employees_fact)
                .HasForeignKey(e => e.spr_employees_id_fact)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_employees>()
                .HasMany(e => e.data_services_smev_request)
                .WithRequired(e => e.spr_employees)
                .HasForeignKey(e => e.spr_employees_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_employees>()
                .HasMany(e => e.data_services_view_log)
                .WithRequired(e => e.spr_employees)
                .HasForeignKey(e => e.spr_employees_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_employees>()
                .HasMany(e => e.spr_employees_role_join)
                .WithRequired(e => e.spr_employees)
                .HasForeignKey(e => e.spr_employees_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_employees_department>()
                .HasMany(e => e.spr_employees)
                .WithRequired(e => e.spr_employees_department)
                .HasForeignKey(e => e.spr_employees_department_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_employees_job_pos>()
                .HasMany(e => e.data_services_execution)
                .WithOptional(e => e.spr_employees_job_pos_execution)
                .HasForeignKey(e => e.spr_employees_job_pos_id_execution);

            modelBuilder.Entity<spr_employees_job_pos>()
                .HasMany(e => e.data_services)
                .WithRequired(e => e.spr_employees_job_pos)
                .HasForeignKey(e => e.spr_employees_job_pos_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_employees_role>()
                .HasMany(e => e.spr_employees_role_join)
                .WithRequired(e => e.spr_employees_role)
                .HasForeignKey(e => e.spr_employees_role_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_hunting_farm>()
                .Property(e => e.hunting_farm_area)
                .HasPrecision(15, 2);

            modelBuilder.Entity<spr_hunting_farm>()
                .HasMany(e => e.spr_hunting_farm_season)
                .WithRequired(e => e.spr_hunting_farm)
                .HasForeignKey(e => e.spr_hunting_farm_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_hunting_farm_season>()
                .HasMany(e => e.spr_hunting_farm_season_forms)
                .WithRequired(e => e.spr_hunting_farm_season)
                .HasForeignKey(e => e.spr_hunting_farm_season_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_hunting_farm_season_animal>()
                .HasMany(e => e.spr_hunting_farm_limit)
                .WithRequired(e => e.spr_hunting_farm_season_animal)
                .HasForeignKey(e => e.spr_hunting_farm_season_animal_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_hunting_farm>()
                .HasMany(e => e.spr_hunting_farm_animal)
                .WithRequired(e => e.spr_hunting_farm)
                .HasForeignKey(e => e.spr_hunting_farm_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_hunting_farm_animal>()
                .Property(e => e.area_habitat)
                .HasPrecision(15, 2);

            modelBuilder.Entity<spr_hunting_farm_type>()
                .HasMany(e => e.spr_hunting_farm)
                .WithRequired(e => e.spr_hunting_farm_type)
                .HasForeignKey(e => e.spr_hunting_farm_type_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_hunting_type>()
                .HasMany(e => e.data_customer_hunting_lic_perm)
                .WithRequired(e => e.spr_hunting_type)
                .HasForeignKey(e => e.spr_hunting_type_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_method_remove>()
                .HasMany(e => e.data_customer_hunting_lic_perm)
                .WithRequired(e => e.spr_method_remove)
                .HasForeignKey(e => e.spr_method_remove_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_legal_person>()
                .HasMany(e => e.spr_hunting_farm)
                .WithRequired(e => e.spr_legal_person)
                .HasForeignKey(e => e.spr_legal_person_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_routes_stage>()
                .HasMany(e => e.data_services_routes_stage)
                .WithRequired(e => e.spr_routes_stage)
                .HasForeignKey(e => e.spr_routes_stage_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_routes_stage>()
                .HasMany(e => e.spr_routes_stage_next)
                .WithRequired(e => e.spr_routes_stage)
                .HasForeignKey(e => e.spr_routes_stage_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_routes_stage>()
                .HasMany(e => e.spr_routes_stage_next1)
                .WithRequired(e => e.spr_routes_stage1)
                .HasForeignKey(e => e.spr_routes_stage_next_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services>()
                .HasMany(e => e.spr_services_sub)
                .WithRequired(e => e.spr_services)
                .HasForeignKey(e => e.spr_services_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub>()
                .HasMany(e => e.spr_services_sub_active)
                .WithRequired(e => e.spr_services_sub)
                .HasForeignKey(e => e.spr_services_sub_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub>()
                .HasMany(e => e.spr_services_sub_customer)
                .WithRequired(e => e.spr_services_sub)
                .HasForeignKey(e => e.spr_services_sub_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub>()
                .HasMany(e => e.spr_services_sub_document)
                .WithRequired(e => e.spr_services_sub)
                .HasForeignKey(e => e.spr_services_sub_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub>()
                .HasMany(e => e.spr_services_sub_failure_doc)
                .WithRequired(e => e.spr_services_sub)
                .HasForeignKey(e => e.spr_services_sub_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub>()
                .HasMany(e => e.spr_services_sub_failure)
                .WithRequired(e => e.spr_services_sub)
                .HasForeignKey(e => e.spr_services_sub_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub>()
                .HasMany(e => e.spr_services_sub_file_folder)
                .WithRequired(e => e.spr_services_sub)
                .HasForeignKey(e => e.spr_services_sub_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub>()
                .HasMany(e => e.spr_services_sub_result_doc)
                .WithRequired(e => e.spr_services_sub)
                .HasForeignKey(e => e.spr_services_sub_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub>()
                .HasMany(e => e.spr_services_sub_smev_request_join)
                .WithRequired(e => e.spr_services_sub)
                .HasForeignKey(e => e.spr_services_sub_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub>()
                .HasMany(e => e.spr_services_sub_stop)
                .WithRequired(e => e.spr_services_sub)
                .HasForeignKey(e => e.spr_services_sub_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub>()
                .HasMany(e => e.spr_services_sub_type_quality_join)
                .WithRequired(e => e.spr_services_sub)
                .HasForeignKey(e => e.spr_services_sub_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub>()
                .HasMany(e => e.spr_services_sub_way_get_join)
                .WithRequired(e => e.spr_services_sub)
                .HasForeignKey(e => e.spr_services_sub_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub>()
                .HasMany(e => e.spr_services_sub_way_get_result_join)
                .WithRequired(e => e.spr_services_sub)
                .HasForeignKey(e => e.spr_services_sub_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub_customer>()
                .HasMany(e => e.spr_services_sub_document_customer)
                .WithRequired(e => e.spr_services_sub_customer)
                .HasForeignKey(e => e.spr_services_sub_customer_id);

            modelBuilder.Entity<spr_services_sub_customer>()
                .HasMany(e => e.spr_services_sub_tariff)
                .WithRequired(e => e.spr_services_sub_customer)
                .HasForeignKey(e => e.spr_services_sub_customer_id);

            modelBuilder.Entity<spr_services_sub_file_folder>()
                .HasMany(e => e.spr_services_sub_file)
                .WithRequired(e => e.spr_services_sub_file_folder)
                .HasForeignKey(e => e.spr_services_sub_file_folder_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub_status>()
                .HasMany(e => e.data_services)
                .WithRequired(e => e.spr_services_sub_status)
                .HasForeignKey(e => e.spr_services_sub_status_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub_tariff>()
                .Property(e => e.tariff_)
                .HasPrecision(15, 2);

            modelBuilder.Entity<spr_services_sub_tariff_type>()
                .HasMany(e => e.data_services)
                .WithOptional(e => e.spr_services_sub_tariff_type)
                .HasForeignKey(e => e.spr_services_sub_tariff_type_id);

            modelBuilder.Entity<spr_services_sub_type_quality>()
                .HasMany(e => e.spr_services_sub_type_quality_join)
                .WithRequired(e => e.spr_services_sub_type_quality)
                .HasForeignKey(e => e.spr_services_sub_type_quality_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub_type_recipient>()
                .HasMany(e => e.data_services)
                .WithRequired(e => e.spr_services_sub_type_recipient)
                .HasForeignKey(e => e.spr_services_sub_tr_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub_type_recipient>()
                .HasMany(e => e.data_services_customer)
                .WithRequired(e => e.spr_services_sub_type_recipient)
                .HasForeignKey(e => e.spr_services_sub_tr_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub_type_recipient>()
                .HasMany(e => e.spr_services_sub_customer)
                .WithRequired(e => e.spr_services_sub_type_recipient)
                .HasForeignKey(e => e.spr_services_sub_type_recipient_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub_way_get>()
                .HasMany(e => e.data_services)
                .WithRequired(e => e.spr_services_sub_way_get)
                .HasForeignKey(e => e.spr_services_sub_way_get_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub_way_get>()
                .HasMany(e => e.spr_services_sub_way_get_join)
                .WithRequired(e => e.spr_services_sub_way_get)
                .HasForeignKey(e => e.spr_services_sub_way_get_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub_way_get_result>()
                .HasMany(e => e.spr_services_sub_way_get_result_join)
                .WithRequired(e => e.spr_services_sub_way_get_result)
                .HasForeignKey(e => e.spr_services_sub_way_get_result_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub_week>()
                .HasMany(e => e.data_services)
                .WithRequired(e => e.spr_services_sub_week)
                .HasForeignKey(e => e.spr_services_sub_week_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub_week>()
                .HasMany(e => e.data_services_routes_stage)
                .WithRequired(e => e.spr_services_sub_week)
                .HasForeignKey(e => e.spr_services_sub_week_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub_week>()
                .HasMany(e => e.data_services_smev_request)
                .WithOptional(e => e.spr_services_sub_week)
                .HasForeignKey(e => e.spr_services_sub_week_id);

            modelBuilder.Entity<spr_services_sub_week>()
                .HasMany(e => e.spr_services_sub_stop)
                .WithRequired(e => e.spr_services_sub_week)
                .HasForeignKey(e => e.spr_services_sub_week_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub_week>()
                .HasMany(e => e.spr_services_sub_tariff)
                .WithRequired(e => e.spr_services_sub_week)
                .HasForeignKey(e => e.spr_services_sub_week_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_sub_week>()
                .HasMany(e => e.spr_smev_request)
                .WithRequired(e => e.spr_services_sub_week)
                .HasForeignKey(e => e.spr_services_sub_week_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_services_type>()
                .HasMany(e => e.spr_services)
                .WithRequired(e => e.spr_services_type)
                .HasForeignKey(e => e.spr_services_type_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_smev>()
                .HasMany(e => e.spr_smev_request)
                .WithRequired(e => e.spr_smev)
                .HasForeignKey(e => e.spr_smev_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_smev_request>()
                .HasMany(e => e.data_services_smev_request)
                .WithRequired(e => e.spr_smev_request)
                .HasForeignKey(e => e.spr_smev_request_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_smev_request>()
                .HasMany(e => e.spr_services_sub_smev_request_join)
                .WithRequired(e => e.spr_smev_request)
                .HasForeignKey(e => e.spr_smev_request_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_smev_type_request>()
                .HasMany(e => e.spr_smev_request)
                .WithRequired(e => e.spr_smev_type_request)
                .HasForeignKey(e => e.spr_smev_type_request_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_standards_file>()
                .HasMany(e => e.spr_services_sub_file)
                .WithRequired(e => e.spr_standards_file)
                .HasForeignKey(e => e.spr_standards_file_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_violations_part>()
                .HasMany(e => e.data_customer_violations)
                .WithOptional(e => e.spr_violations_part)
                .HasForeignKey(e => e.pr_spr_violations_part_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_bailiffs_result>()
                .HasMany(e => e.data_customer_violations)
                .WithOptional(e => e.spr_bailiffs_result)
                .HasForeignKey(e => e.bai_spr_bailiffs_result_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_organization_result>()
                .HasMany(e => e.data_customer_violations)
                .WithOptional(e => e.spr_organization_result)
                .HasForeignKey(e => e.tr_spr_organization_result_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_violations>()
                .HasMany(e => e.spr_violations_part)
                .WithRequired(e => e.spr_violations)
                .HasForeignKey(e => e.spr_violations_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<data_customer_violations>()
               .HasMany(e => e.data_customer_violations_file)
               .WithRequired(e => e.data_customer_violations)
               .HasForeignKey(e => e.data_customer_violations_id)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<data_services_commentt>()
                .HasMany(e => e.data_services_commentt_recipient)
                .WithRequired(e => e.data_services_commentt)
                .HasForeignKey(e => e.data_services_commentt_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_employees>()
                .HasMany(e => e.data_services_commentt_recipient)
                .WithRequired(e => e.spr_employees)
                .HasForeignKey(e => e.spr_employees_id_recipient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<data_customer_hunting_lic_perm_payment>()
                .Property(e => e.payment_value)
                .HasPrecision(15, 2);

            modelBuilder.Entity<spr_taxation>()
                .HasMany(e => e.data_customer_hunting_lic_perm_payment)
                .WithOptional(e => e.spr_taxation)
                .HasForeignKey(e => e.spr_taxation_id);

            modelBuilder.Entity<data_customer>()
                .HasMany(e => e.data_customer_hunting_lic_perm_payment)
                .WithRequired(e => e.data_customer)
                .HasForeignKey(e => e.data_customer_id);

            modelBuilder.Entity<spr_employees>()
                .HasMany(e => e.data_customer_hunting_lic_perm_payment)
                .WithRequired(e => e.spr_employees)
                .HasForeignKey(e => e.spr_employees_id);

            modelBuilder.Entity<spr_animal>()
                .HasMany(e => e.spr_season_animal)
                .WithRequired(e => e.spr_animal)
                .HasForeignKey(e => e.spr_animal_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<spr_season>()
                .Property(e => e.tariff_)
                .HasPrecision(15, 2);

            modelBuilder.Entity<spr_season>()
                .Property(e => e.charge_)
                .HasPrecision(15, 2);

            modelBuilder.Entity<spr_season>()
                .HasMany(e => e.spr_season_animal)
                .WithRequired(e => e.spr_season)
                .HasForeignKey(e => e.spr_season_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Spr_Kcr>().ToTable("spr_kcr", "public");
            modelBuilder.Entity<Data_Kcr>().ToTable("data_kcr", "public");
        }
    }
}

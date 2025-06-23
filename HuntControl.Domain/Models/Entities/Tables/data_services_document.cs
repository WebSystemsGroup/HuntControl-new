namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_services_document")]
    public partial class data_services_document
    {
        public Guid id { get; set; }

        [Required]
        [StringLength(70)]
        public string data_services_info_id { get; set; }

        public Guid spr_documents_id { get; set; }

        public short document_count { get; set; }

        [StringLength(255)]
        public string commentt { get; set; }

        public Guid data_services_id { get; set; }

        public short document_type { get; set; }

        public short document_needs { get; set; }

        public virtual data_services data_services { get; set; }

        public virtual spr_documents spr_documents { get; set; }
    }
}

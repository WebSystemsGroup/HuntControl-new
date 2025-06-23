namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StatementDocumentSelectResult
    {
        public Guid? out_id { get; set; }
        public string out_document_name { get; set; }
        public short? out_document_type { get; set; }
        public short? out_document_count { get; set; }
        public short? out_document_needs { get; set; }
        public short? out_file_count { get; set; }
    }
}

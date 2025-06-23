namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FtpSettings
    {
        [Display(Name = "������")]
        public string out_ftp_server { get; set; }
        [Display(Name = "������������")]
        public string out_ftp_user { get; set; }
        [Display(Name = "�����")]
        public string out_ftp_folder { get; set; }
        [Display(Name = "������")]
        public string out_ftp_password { get; set; }
    }
}
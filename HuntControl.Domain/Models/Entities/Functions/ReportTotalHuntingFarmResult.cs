namespace HuntControl.Domain.Concrete
{
    using System.ComponentModel.DataAnnotations;

    public partial class ReportTotalHuntingFarmResult
    {
        [Display(Name = "����������")]
        public string out_hunting_farm_name { get; set; }

        [Display(Name = "���������� �������")]
        public int? out_count_form { get; set; }

        [Display(Name = "���������� ������� ������")]
        public int? out_count_form_issued { get; set; }

        [Display(Name = "���������� ������� ��������")]
        public int? out_count_form_result { get; set; }

        [Display(Name = "���������� ��������")]
        public int? out_limit_animal { get; set; }

        [Display(Name = "���������� �������� ������")]
        public int? out_count_animal_mined { get; set; }

        [Display(Name = "���������� �������� ������")]
        public int? out_count_animal_issued { get; set; }

        [Display(Name = "���������� �������� ��������")]
        public int? out_count_animal_result { get; set; }
    }
}

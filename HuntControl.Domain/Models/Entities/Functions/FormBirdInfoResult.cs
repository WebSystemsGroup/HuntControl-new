namespace HuntControl.Domain.Concrete
{
    using System;

    public partial class FormAnimalSelectResult
    {
        public string out_date_start { get; set; }
        public string out_date_stop { get; set; }
        public string out_animal_name { get; set; }
        public string out_limit_day { get; set; }
        public string out_limit_season { get; set; }
    }
}

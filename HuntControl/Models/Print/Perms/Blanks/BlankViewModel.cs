using System.Collections.Generic;
using HuntControl.Domain.Concrete;

namespace HuntControl.WebUI.Models.Print.Perms.Blanks
{
    public class BlankViewModel<T>
    {
        public IEnumerable<FormAnimalSelectResult> AnimalList { get; set; }
        public T Model { get; set; }
    }
}
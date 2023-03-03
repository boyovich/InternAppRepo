using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InternApp.Domain
{
    public enum Position
    {
        Manager,
        [Description("Software Developer")]
        Software_Developer,
        [Description("Quality assurance")]
        QA,
        Stuff
    }
}
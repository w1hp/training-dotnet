using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cvl.Training.SmsEmailSender.Core.Base
{
    [Index(nameof(SimpleSearchIndex))]
    public class BaseEntity
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [ScaffoldColumn(false)]
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// If true - object is removed
        /// </summary>
        [ScaffoldColumn(false)]
        [Display(Name = "Czy usunięt/archiwalny")]
        public bool Archival { get; set; } = false;

        /// <summary>
        /// date of object creation
        /// </summary>
        [Display(Name = "Data utworzenia")]
        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Data modufikacji")]
        [ScaffoldColumn(false)]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        [ScaffoldColumn(false)]
        public string SimpleSearchIndex { get; set; } = string.Empty;

        public override string ToString()
        {
            var properties = GetType().GetProperties();
            var sb = new StringBuilder();
            foreach (var propertyInfo in properties)
            {
                if (propertyInfo.Name == nameof(SimpleSearchIndex))
                    continue;
                if (propertyInfo.PropertyType.IsValueType == true || propertyInfo.PropertyType == typeof(string))
                {
                    var value = propertyInfo.GetValue(this);
                    if (value != null)
                    {
                        var strVal = value.ToString()?.ToLower() ?? "";
                        if (sb.Length + strVal.Length < 2700) //max rozmiar indexu
                        {
                            sb.Append(strVal);
                            sb.Append(" ");
                        }
                    }
                }
                else
                {

                }
            }

            return sb.ToString();
        }
    }
}

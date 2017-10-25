using Metadata.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metadata.Metadata
{
    
    class METAContact
    {
        [RegularExpression("[A-Z]{2,45}",ErrorMessage="Tout en majuscule")] 
        public string Nom { get; set; }
        
        [RegularExpression("[0-9]{5,}")]
        [MaxLength(5)]
        public string Cp { get; set; }
        
        [EmailAddress(ErrorMessage="Erreur d'email")]
        [MaxLength(10, ErrorMessage="Longueur d'email invalide")]
        public string Email { get; set; }
        
    }
}

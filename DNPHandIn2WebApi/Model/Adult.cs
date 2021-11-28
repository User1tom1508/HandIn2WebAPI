using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models;

namespace DNPHandIn2WebApi.Model {
public class Adult : Person {
    
    public Job Job { get; set; }
}
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Utilities;


[NotMapped]
public class ChosenItem
{
    public int ChosenId { get; set; }
    public string ChosenName { get; set; }
    public bool IsChosen { get; set; }
}

[NotMapped]
public class ChosenItemList
{
    public List<ChosenItem> myList { get; set; }
}

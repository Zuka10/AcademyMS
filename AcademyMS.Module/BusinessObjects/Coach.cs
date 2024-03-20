using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace AcademyMS.Module.BusinessObjects;

[DefaultClassOptions]
public class Coach : BaseObject
{ 
    public Coach(Session session) : base(session) { }

    public override void AfterConstruction()
    {
        base.AfterConstruction();
    }

    private string _firstName;
    public string FirstName
    {
        get { return _firstName; }
        set { SetPropertyValue(nameof(FirstName), ref _firstName, value); }
    }

    private string _lastName;
    public string LastName
    {
        get { return _lastName; }
        set { SetPropertyValue(nameof(LastName), ref _lastName, value); }
    }

    private string _personalNumber;
    public string PersonalNumber
    {
        get { return _personalNumber; }
        set { SetPropertyValue(nameof(PersonalNumber), ref _personalNumber, value); }
    }

    private DateTime _birthDate;
    public DateTime BirthDate
    {
        get { return _birthDate; }
        set { if (SetPropertyValue(nameof(BirthDate), ref _birthDate, value)) { CalculateAge(); } }
    }

    private int _age;
    [ModelDefault("AllowEdit", "False")]
    public int Age
    {
        get { return _age; }
        set { SetPropertyValue(nameof(Age), ref _age, value); }
    }

    [Association("Coach-Teams")]
    public XPCollection<Team> Teams
    {
        get { return GetCollection<Team>(nameof(Teams)); }
    }

    private void CalculateAge()
    {
        Age = DateTime.Today.Year - BirthDate.Year;
        if (BirthDate.Year > DateTime.Today.Year)
        {
            Age = 0;
            throw new UserFriendlyException("Birth date cannot be more than actual date");
        }
    }
}
using DevExpress.DirectX.Common.Direct2D;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace AcademyMS.Module.BusinessObjects;

[DefaultClassOptions]
public class Player : BaseObject
{
    public Player(Session session) : base(session) { }

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

    private string _paretName;
    public string ParentName
    {
        get { return _paretName; }
        set { SetPropertyValue(nameof(ParentName), ref _paretName, value); }
    }

    private string _parentPhoneNumber;
    public string ParentPhoneNumber
    {
        get { return _parentPhoneNumber; }
        set { SetPropertyValue(nameof(ParentPhoneNumber), ref _parentPhoneNumber, value); }
    }

    private Team _team;
    [Association("Team-Players")]
    public Team Team
    {
        get { return _team; }
        set { SetPropertyValue(nameof(Team), ref _team, value); }
    }

    private string _note;
    [Size(SizeAttribute.Unlimited)]
    public string Note
    {
        get { return _note; }
        set { SetPropertyValue(nameof(Note), ref _note, value); }
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
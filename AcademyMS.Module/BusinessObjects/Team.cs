using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.ComponentModel;

namespace AcademyMS.Module.BusinessObjects;

[DefaultClassOptions]
[DefaultProperty("Name")]
public class Team : BaseObject
{ 
    public Team(Session session) : base(session) { }

    public override void AfterConstruction()
    {
        base.AfterConstruction();
    }

    private string _name;
    public string Name
    {
        get { return _name; }
        set { SetPropertyValue(nameof(Name), ref _name, value); }
    }

    private Coach _coach;
    [Association("Coach-Teams")]
    public Coach Coach
    {
        get { return _coach;}
        set { SetPropertyValue(nameof(Coach), ref _coach, value); }
    }

    [Association("Team-Players")]
    public XPCollection<Player> Players
    {
        get { return GetCollection<Player>(nameof(Players)); }
    }
}
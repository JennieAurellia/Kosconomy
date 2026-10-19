public abstract class PlayerStat
{
    public int InitMoney { get; protected set; }
    private int _currentMoney;
    public int CurrentMoney
    {
        get { return _currentMoney; }
        set
        {
            _currentMoney = value;
        }
    }

    public int MaxEnergy { get; protected set; }
    private int _currentEnergy;
    public int CurrentEnergy
    {
        get { return _currentEnergy; }
        set
        {
            _currentEnergy = value;
        }
    }

    public int InitRelation { get; protected set; }
    private int _currentRelation;
    public int CurrentRelation
    {
        get { return _currentRelation; }
        set
        {
            _currentRelation = value;
        }
    }
    
    private bool _playDialog;
    public bool PlayDialog
    {
        get { return _playDialog; }
        set
        {
            _playDialog = value;
        }
    }

    public PlayerStat(int initMoney, int maxEnergy, int initRelation, bool playDialog)
    {
        CurrentMoney = initMoney;
        CurrentEnergy = maxEnergy;
        CurrentRelation = initRelation;
        PlayDialog = playDialog;
    }

    public virtual void AddMoney(int money)
    {
        CurrentMoney += money; 
    }
    public virtual void AddEnergy(int energy)
    {
        CurrentEnergy += energy;
    }
    public virtual void AddRelation(int relation)
    {
        CurrentRelation += relation;
    }
    public virtual void ChangePlayDialog(bool playDialog)
    {
        PlayDialog = playDialog;
    }

}

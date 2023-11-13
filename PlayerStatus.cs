public class PlayerStatus : MonoBehaviour {

    // health variables
    public int maxHealth = 100;
    public int curHealth = 100;

    // stamina variables
    public float maxStamina = 100;
    public float curStamina = 100;

    public bool disabled = FALSE;
    // public bool dead = FALSE;
    // while dead == FALSE: - game continues




    void Start () {
        //healthBarLength = Screen.width / 2;
    }

    // Update is called once per frame
    void Update () {
        AddCurrentHealth(1);
        AddCurrentStamina(1);
    }

    public void AddCurrentHealth(int adj) {
        curHealth += adj;

        if(curHealth < 0)
            curHealth = 0;

        if(curHealth > maxHealth)
            curHealth = maxHealth;
    }

    public void AddCurrentStamina(int adj) {
        curStamina += adj;

        if(curStamina < 0)
            curStamina = 0;

        if(curStamina > maxStamina)
            curStamina = maxStamina;
    }
}
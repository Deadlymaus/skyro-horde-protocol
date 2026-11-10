| Stav | Čo vlna robí |
| --- | --- |
| `Run` | Vlna beží. Hráč sa hýbe a strieľa, strela letí, nepriateľ ide |
| `Pause` | Vlna stojí na mieste. Ďalšie `Pause` pokračuje v tej istej vlne, nie od začiatku |
| `GameOver` | Vlna sa skončila smrťou. Stojí, kým nepríde `Retry` |


| Príkaz | `Run` | `Pause` | `GameOver` |
| --- | --- | --- | --- |
| `Move` | vykoná sa | zahodí sa | zahodí sa |
| `Fire` | vykoná sa | zahodí sa | zahodí sa |
| `Pause` | prejde do `Pause` | prejde do `Run` | zahodí sa |
| `Retry` | zahodí sa | zahodí sa | načíta Arénu znova |


1. Vlna beží a hráč stlačí `Pause`. Aký je stav a kde ostanú nepriatelia? - Stav = Pause; Nepriatel.transform.position = Nepriatel.transform.positon;
2. Vlna je v pauze a nepriateľ sa dotkne hráča. Aký je stav? - Stav = Pause;
3. Hráč je v `GameOver` a stlačí `Fire`. Čo spraví `Submit` ? - Stav = Run;
4. Jednou vetou: čo z náčrtu `GameManager` dnes nesmie skončiť v jednej triede, a ktorá z vašich tried to bude držať namiesto nej?

  - if (paused) return;
    if (dead) return;

 - class PausedState : MonoBehaviour
  {
    void Update()
    {
      if(paused) return;
    }
  }

 - class DeadState : MonoBehaviour
  {
    void Update()
    {
      if(dead) return;
    }
  }
 

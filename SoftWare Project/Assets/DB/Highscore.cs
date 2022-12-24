using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// public class Highscore : IComparable<Highscore>
public class Highscore
{
    public string score { get; set; }
    public string name { get; set; }
    public DateTime Date { get; set; }
    public int ID { get; set; }

    public Highscore(int id, string score, string name, DateTime date)
    {
        this.score = score;
        this.ID = id;
        this.name = name;
        this.Date = date;
    }

    // public int CompareTo(Highscore other)
    // {
    //     if(other.score.Second < this.score.Second || other.score.Minute < this.score.Minute)
    //     {
    //         return -1;
    //     }
    //     else if(other.score.Second > this.score.Second || other.score.Minute > this.score.Minute)
    //     {
    //         return 1;
    //     }
    //     else if (other.Date < this.Date)
    //     {
    //         return -1;
    //     }
    //     else if (other.Date > this.Date)
    //     {
    //         return 1;
    //     }
    //     return 0;
    // }
}
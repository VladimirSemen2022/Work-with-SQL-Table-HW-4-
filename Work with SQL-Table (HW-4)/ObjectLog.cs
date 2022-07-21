using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_with_SQL_Table__HW_4_
{
    public class ObjectLog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Weapone { get; set; }

        public int HP { get; set; }
        public string Action { get; set; }

        public DateTime DateTime { get; set; }

        public override string ToString()
        {
            return $"{Id}) Name: {Name} Type: {Type} Weapone: {Weapone} HP {HP} Action: {Action} DateTime {DateTime}\n";
        }

        private ObjectLog()
        { }

        public ObjectLog(int id, string name, string type, string weapone, int hp, string action, DateTime dateTime)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.Weapone = weapone;
            this.HP = hp;
            this.Action = action;
            this.DateTime = dateTime;
        }
    }
}

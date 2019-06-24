﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Source.PeopleSoft.Models
{
    public class Person
    {
        [Column(name:"P_ID")]
        public int Id { get; set; }
        [Column(name: "KUERZEL")]
        public string ShortName { get; set; }
        [Column(name: "VORNAME")]
        public string FirstName { get; set; }
        [Column(name: "NAME")]
        public string LastName { get; set; }
        [Column(name: "TITEL")]
        public string Title { get; set; }
        [Column(name: "TELEFON")]
        public string Phone { get; set; }
        [Column(name: "MOBIL")]
        public string MobilPhone { get; set; }
        [Column(name:"FAX")]
        public string FAX { get; set; }
        [Column(name: "EMAIL")]
        public string EMail { get; set; }
        [Column(name: "MITARBEITER_STATUS_ID")]
        public int StatusId { get; set; }
        // TODO: missing view in database!
        // Currently not working
        // public Status Status { get; set; }
        [Column(name: "ORG_ID")]
        public int OrgUnitId { get; set; }
        // Currently not working
        // public OrgUnit OrgUnit { get; set; }
        [Column(name: "F_ID")]
        public int? FunctionId { get; set; }
        // TODO: missing view in database!
        // Currently not working
        // public Function Function { get; set; }
        [Column(name: "RAUM_ID")]
        public int? RoomId { get; set; }
        // Currently not working
        // public Room Room { get; set; }
    }
}
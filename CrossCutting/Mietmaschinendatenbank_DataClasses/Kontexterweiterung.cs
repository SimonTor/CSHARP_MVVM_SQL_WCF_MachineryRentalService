using System;
using System.IO;
using System.Collections.Generic;
using System.Data.Objects;

namespace CrossCutting.Mietmaschinendatenbank_DataClasses
{
    public partial class MietmaschinendatenbankModelContainer
    {
        public static string Protokolldatei;
        static MietmaschinendatenbankModelContainer()
        {
            Protokolldatei = Path.Combine(@"c:\temp", "EFLog.csv");            
        }

        /*
        /// <summary>
        /// Überschreiben von SaveChanges: Zusätzliches Protokollieren in Datei
        /// </summary>
        public override int SaveChanges(System.Data.Objects.SaveOptions options)
        {
            List<ObjectStateEntry> neue = new List<ObjectStateEntry>();

            // Alle Ändeurngen aus den Objekten sammeln
            this.DetectChanges();

            // Hole Geänderte
            foreach (var ose in this.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Modified))
            {
                foreach (var mprop in ose.GetModifiedProperties())
                {
                    WriteProtokoll(ose.EntitySet.Name, (int)ose.EntityKey.EntityKeyValues[0].Value, "Modified", mprop, ose.OriginalValues[mprop].ToString(), ose.CurrentValues[mprop].ToString(), "");
                }
            }


            // Hole Neue
            foreach (var ose in this.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Added))
            {
                // Erstmal nur merken, denn die Autowerte sind noch nicht gesetzt!
                neue.Add(ose);
            }


            // Hole Gelöschte
            foreach (var ose in this.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Deleted))
            {
                WriteProtokoll(ose.EntitySet.Name, (int)ose.EntityKey.EntityKeyValues[0].Value, "Deleted", "", "", "", "");
            }

            // Nun Standardimplementierung aufrufen
            int Anzahl = base.SaveChanges(options);

            // Jetzt noch die neuen behandeln
            foreach (var ose in neue)
            {
                if (ose.EntityKey != null && ose.EntityKey.EntityKeyValues != null) WriteProtokoll(ose.EntitySet.Name, (int)ose.EntityKey.EntityKeyValues[0].Value, "Added", "", "", "", "");
            }


            return Anzahl;
        }*/
        
        /// <summary>
        /// Erzeuge Protokolleintrag
        /// </summary>
        public void WriteProtokoll(string Entity, int EntityID, string Aktion, string Attribut, string AlterWert, string NeuerWert, string Text)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(MietmaschinendatenbankModelContainer.Protokolldatei, true);

            sw.WriteLine(System.Environment.UserDomainName + "\\" + System.Environment.UserName + ";" + DateTime.Now + ";" + Entity + ";" + EntityID + ";" + Aktion + ";" + Attribut + ";" + AlterWert + ";" + NeuerWert + ";" + Text);
            sw.Close();
        } 
    }
   
    }

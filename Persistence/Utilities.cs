using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class Utilities
    {
        [DataContract]
        [Flags]
        public enum Elenco_Stati
        {
            FILE_ELABORATO = 0,
            FILE_IN_LAVORAZIONE = 1,
            FILE_SCARTATO = 2
        }
        [DataContract]
        [Flags]
        public enum Elenco_Entita
        {
            FILE_IMM = 0
        }
        [DataContract]
        [Flags]
        public enum Esito_Controlli
        {
            OK = 0,
            UTENTE_NON_TROVATO = 1,
            PIU_UTENTI_TROVATI = 2,
            ERRORE_GENERICO = 3,
            KO = 4,
            SERVIZIO_NON_ATTIVO = 5,
            RECORD_ESISTENTE = 6,
            NESSUN_FILE_DA_LAVORARE = 7,
            NESSUN_RECORD_TROVATO = 8
        }
        [DataContract]
        [Flags]
        public enum Enum_Macchina
        {
            AS = 0,
            WS = 1,
            DB = 2
        }
        [DataContract]
        [Flags]
        public enum Enum_Error
        {
            WARNING = 0,
            ERROR = 1,
            TRACE = 2,
            DEBUG = 3
        }
        [DataContract]
        [Flags]
        public enum Enum_Servizi
        {
            AbilitazioneServizio = 0,
            CheckLogin = 1,
            GetUserById = 2,
            GetUsersByProfiles = 3,
            GetUsersByLanguage = 4,
            AbbinamentoProfiloMenu = 5,
            ChechServizioAbilitato = 6,
            EnableUser = 7,
            GetUser = 8,
            UpdateUser = 9,
            GetUsers = 10,
            AddUsers = 11,
            GetProfiles = 12,
            AddProfile = 13,
            GetProfileById = 14,
            GetProfilesByUserId = 15,
            GetLanguages = 16,
            GetLanguagebyId = 17,
            GetLanguagebyIdUser = 18,
            GetServiceGroups = 19
        }
    }
}

using Raven.Client;
using Raven.Client.Document;

namespace OpenSalary.Web.Core {
    public class DataStore {
        public static IDocumentStore Get() {
            if (_store == null) {
                _store = new DocumentStore() {
                    ConnectionStringName = "RavenDB"
                }.Initialize();
            }
            return _store;
        }
        private static IDocumentStore _store;
    }
}
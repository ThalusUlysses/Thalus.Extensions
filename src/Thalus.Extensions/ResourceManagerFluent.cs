using System.Globalization;
using System.IO;
using System.Resources;

namespace Thalus.Extensions
{
    public class ResourceManagerFluent
    {
        private string _id;
        private bool _asInvariant;

        private object[] _param;

        private ResourceManager _mgmr;

        public ResourceManagerFluent(ResourceManager mgmr)
        {
            _mgmr = mgmr;
        }

        public ResourceManagerFluent Resource(string resourceId)
        {
            _id = resourceId;
            return this;

        }

        public ResourceManagerFluent AsInvariant()
        {
            _asInvariant = true;
            return this;
        }

        public ResourceManagerFluent With(params object[] par)
        {
            _param = par;
            return this;
        }

        public (string,string) AsStrings()
        {
            ResourceManagerFluent invariant = new ResourceManagerFluent(_mgmr);
            ResourceManagerFluent current = new ResourceManagerFluent(_mgmr);
            
            var t =  (current.With(_param).Resource(_id).AsString(), invariant.Resource(_id).AsInvariant().With(_param).AsString());

            _id = null;
            _param = null;
            _asInvariant = false;

            return t;
        }

        public string AsString()
        {
            var p = _mgmr.GetString(_id, _asInvariant ? CultureInfo.InvariantCulture : CultureInfo.CurrentUICulture);

            if (_param != null)
            {

                return string.Format(p, _param);
            }

            _asInvariant = false;
            _id = null;
            _param = null;
            return p;
        }

        public object AsObject()
        {
            var i = _mgmr.GetObject(_id, _asInvariant ? CultureInfo.InvariantCulture : CultureInfo.CurrentUICulture);

            _asInvariant = false;
            _id = null;
            _param = null;

            return i;
        }

        public Stream AsStream()
        {
            var i =  _mgmr.GetStream(_id, _asInvariant ? CultureInfo.InvariantCulture : CultureInfo.CurrentUICulture);

            _asInvariant = false;
            _id = null;
            _param = null;

            return i;
        }

    }
}
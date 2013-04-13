using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suzy.BO
{
    /// <summary>
    /// Этот класс работает с Локациями
    /// </summary>
    public class LocationArea
    {
        private location_area _location_area;

        public int id { get { return _location_area.id; } private set { _location_area.id = value; } }
        public string name { get { return _location_area.name; } set { _location_area.name = value; } }
        public float lattitude { get { return _location_area.lattitude; } set { _location_area.lattitude = value; } }
        public float longtitude { get { return _location_area.longtitude; } set { _location_area.longtitude = value; } }
        public float radius { get { return _location_area.radius; } set { _location_area.radius = value; } }
        public int id_account { get { return _location_area.id_account; }  set { _location_area.id_account = value; } }
        public DateTime time_of_marking { get { return _location_area.time_of_marking; } set { _location_area.time_of_marking = value; } }

        /// <summary>
        /// Этот метод сохраняет нашу Локацию в БД
        /// </summary>

        public void Save()
        {
            using (OurDB db = new OurDB())
            {
                var location_area = db.Location_areas.Find(id);
                location_area.id = this.id;
                location_area.name = this.name;
                location_area.lattitude = this.lattitude;
                location_area.longtitude = this.longtitude;
                location_area.radius = this.radius;
                location_area.id_account = this.id_account;
                location_area.time_of_marking = this.time_of_marking;
                db.SaveChanges();
            }

        }

        internal LocationArea(location_area _Location_area)
        {
			_location_area = _Location_area;
        }

        /// <summary>
        /// Это наш конструктор для LocationArea без параметров
        /// </summary>

        public LocationArea()
        {
			_location_area = new location_area();
        }

        /// <summary>
        /// Данный метод проверяет сравнивает два объекта типа LocationArea
        /// </summary>
        /// <param name="obj">Передается объект, с которым будем работать</param>
        /// <returns>Возращает значение false, если объекты не совпадают</returns>

        public override bool Equals(object obj)
        {
            if (obj is LocationArea)
            {
                LocationArea areaObj = obj as LocationArea;
                if (areaObj == null)
                    return false;
                else if (this._location_area == areaObj._location_area)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}

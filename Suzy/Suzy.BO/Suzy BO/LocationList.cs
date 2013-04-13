using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suzy.BO
{
    /// <summary>
    /// Данный класс создает контейнер для оперировании с объектами типа LocalArea
    /// </summary>
    public static class LocationList
    {

        /// <summary>
        /// Метод добавляет в базу данных объект типа LocationArea
        /// </summary>
        /// <param name="location_area">Объект типа LocationArea</param>
        public static void Add(LocationArea location_area)
        {
            location_area _location_area = new location_area();
            _location_area.id_account = location_area.id_account;
            _location_area.name = location_area.name;
            _location_area.lattitude = location_area.lattitude;
            _location_area.longtitude = location_area.longtitude;
            _location_area.radius = location_area.radius;
            _location_area.id = location_area.id;
            _location_area.time_of_marking = location_area.time_of_marking;
            using (OurDB db = new OurDB())
            {
                db.Location_areas.Add(_location_area);
                db.SaveChanges();
            }

        }
        /// <summary>
        /// Данный метод создает из базы данных список локаций
        /// </summary>
        /// <returns>Возвращаем контейнер Локаций с БД</returns>
        public static List<LocationArea> Get()
        {
            using (OurDB db = new OurDB())
            {
                return db.Location_areas.ToList().Select(item => new LocationArea(item)).ToList();
            }

        }

    }
}

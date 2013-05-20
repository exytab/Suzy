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
            using (CustomSuzyEntities db = new CustomSuzyEntities())
            {
                db.location_area.Add(_location_area);
                db.SaveChanges();
            }

        }
        /// <summary>
        /// Данный метод создает из базы данных список локаций
        /// </summary>
        /// <returns>Возвращаем контейнер Локаций с БД</returns>
        public static List<LocationArea> Get()
        {
            using (CustomSuzyEntities db = new CustomSuzyEntities())
            {
                return db.location_area.ToList().Select(item => new LocationArea(item)).ToList();
            }

        }
        /// <summary>
        /// Возвращаем локацию для определенного ID
        /// </summary>
        public static List<LocationArea> GetByAccount(int accountId)
        {
            using (CustomSuzyEntities db = new CustomSuzyEntities())
            {
                return db.location_area.Where(area => area.id_account == accountId).ToList().Select(item => new LocationArea(item)).ToList();
            }
        }

    }
}

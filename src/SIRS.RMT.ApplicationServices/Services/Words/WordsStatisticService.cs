﻿using SIRS.RMT.ApplicationServices.Services.Common;
using SIRS.RMT.Domain.EntityFramework;
using SIRS.RMT.Domain.Memory.Word.Statistics;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SIRS.RMT.ApplicationServices.Services.ColorsExercise
{
    public sealed class WordsStatisticService : CommonService
    {


        #region Поля

        #endregion

        #region Свойства

        #endregion

        #region Методы
        /// <summary>
        /// Сохраняет элемент со статистикой в БД
        /// </summary>
        /// <param name="logItem">элемент со статистикой</param>
        /// <returns></returns>
        public async Task Save(StatisticWordsLog logItem)
        {
            #region Добавляем привязку к тестовому пользователю вручную. Убрать после добавления регистрации!
            // Здесь должен быть GIUD текущего пользователя
            logItem.SetUser(GetUser("F9821756-6A60-4092-9905-6A6A95956ED8"));
            #endregion
            DateTime currentTime = DateTime.Now;
            logItem.Date = DateTime.Now;
            logItem.Time = currentTime - currentTime.Date;
            _ = this.DB.Set<StatisticWordsLog>().Add(logItem);
            _ = await this.DB.SaveChangesAsync();
        }
        /// <summary>
        /// Возвращвает все элементы со статистикой из БД
        /// </summary>
        /// <returns></returns>
        public IQueryable<object> Select()
        {
            var items = this.DB.Set<StatisticWordsLog>();
            var objects = items.Select(x => x.ToObject());
            return objects;
        }
        /// <summary>
        /// Возвращвает все элементы со статистикой из БД для пользователя с указанным GUID
        /// </summary>
        /// <param name="guidUser">GUID пользователя в виде строки</param>
        /// <returns></returns>
        public IQueryable<object> Select(string guidUser)
        {
            var items = this.DB.Set<StatisticWordsLog>().Where(x => x.User.Id == new Guid(guidUser));
            var objects = items.Select(x => x.ToObject());
            return objects;
        }
        #endregion

        #region Конструкторы/Деструкторы
        public WordsStatisticService(ReadingMemoryThinkingDbContext dbContext)
        {
            this.DB = dbContext;
        }
        #endregion

        #region Операторы

        #endregion

        #region Обработчики событий

        #endregion





    }
}
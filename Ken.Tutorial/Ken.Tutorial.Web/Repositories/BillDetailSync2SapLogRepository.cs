using System;
using Ken.Tutorial.Web.Models.Entity;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Ken.Tutorial.Web.Repositories
{
    public class BillDetailSync2SapLogRepository
    {
        private TestDbContext DbContext { get; }

        public BillDetailSync2SapLogRepository(TestDbContext dbContext)
        {
            //在构造函数中注入DbContext
            this.DbContext = dbContext;
        }

        //新增
        public int Add(BillDetailSync2SapLogEntity model)
        {
            using (DbContext)
            {
                //DbContext.Set<BillDetailSync2SapLogEntity>().Add(model);
                DbContext.BillDetailSync2SapLog.Add(model);
                return DbContext.SaveChanges();
            }
        }

        //删除
        public int Del(int id)
        {
            using (DbContext)
            {

                //var model=DbContext.Set<BillDetailSync2SapLogEntity>().FirstOrDefault(it=>it.ID==id);
                //DbContext.Set<BillDetailSync2SapLogEntity>().Remove(model);
                var model = DbContext.BillDetailSync2SapLog.FirstOrDefault(it => it.ID == id);
                DbContext.BillDetailSync2SapLog.Remove(model);
                return DbContext.SaveChanges();
            }
        }

        //更新
        public int Update(BillDetailSync2SapLogEntity model)
        {
            using (DbContext)
            {
                //var entity=DbContext.Entry<BillDetailSync2SapLogEntity>(model);
                //entity.State=EntityState.Modified;
                var entity = DbContext.BillDetailSync2SapLog.FirstOrDefault(it => it.ID == model.ID);
                entity.Msg = model.Msg;
                entity.SyncDate = model.SyncDate;
                entity.SyncFinalState = model.SyncFinalState;
                entity.SyncState = model.SyncState;
                entity.CreateTime = model.CreateTime;
                return DbContext.SaveChanges();
            }
        }

        //单个查询
        public BillDetailSync2SapLogEntity GetById(int id)
        {
            using (DbContext)
            {
                return DbContext.BillDetailSync2SapLog.FirstOrDefault(it => it.ID == id);
            }
        }

        //列表查询
        public List<BillDetailSync2SapLogEntity> GetByState(int state)
        {
            using (DbContext)
            {
                return DbContext.BillDetailSync2SapLog.Where(it => it.SyncFinalState == state).ToList();
            }
        }

        //分页查询
        public List<BillDetailSync2SapLogEntity> GetList(int pageSize, int pageIndex)
        {
            using (DbContext)
            {
                return DbContext.BillDetailSync2SapLog.Where(it => 1 == 1).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        //事务
        public int UpdateState()
        {
            using (DbContext)
            {
                using (var tran = DbContext.Database.BeginTransaction())
                {
                    try
                    {
                        var list = DbContext.BillDetailSync2SapLog.Where(it => it.SyncFinalState == 0);
                        foreach (var item in list)
                        {
                            item.SyncFinalState = 1;
                        }

                        var count = DbContext.SaveChanges();
                        tran.Commit();//提交事务
                        return count;
                    }
                    catch
                    {
                        tran.Rollback();//回滚
                        return 0;
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RC.Common.Utilities;
using RC.Dal.DalFactory;
using RC.Model.DataModel;
using RC.UI.DeveloperTools.Static;

namespace RC.UI.DeveloperTools.BLL
{
    public class ModuleManageBLL
    {
        DbSession _dbSession;
        public ModuleManageBLL()
        {
            IDataBaseInfoBll bll = DataBaseInfoFactory.GetDataBaseInfoBll(DataBaseStaticConfig.Config.provider);
            DbHelper db = bll.SetDbHelperHasDbName(DataBaseStaticConfig.Config);
            _dbSession = DbSessionFactory.GetDbSession<RLFrameWorkEntities>(db.dbConnectionString);
        }
        public List<WdTreeNode> GetTreeEntity()
        {
            List<Base_Module> list = _dbSession.Base_ModuleDal.Entities().OrderBy(o => o.ParentId).ThenBy(o => o.SortCode).ToList();

            List<WdTreeNode> TreeList = new List<WdTreeNode>();
            foreach (Base_Module item in list)
            {
                WdTreeNode tree = new WdTreeNode();
                bool hasChildren = false;
                List<Base_Module> childnode = list.FindAll(t => t.ParentId == item.ModuleId);
                if (childnode.Count > 0)
                {
                    hasChildren = true;
                }
                tree.id = item.ModuleId.ToString();
                tree.text = item.FullName;
                tree.value = item.ModuleId.ToString();
                tree.isexpand = item.Isexpand == 1 ? true : false;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.parentId = item.ParentId.ToString();
                tree.img = item.Icon != null ? "/Content/Images/Icon16/" + item.Icon : item.Icon;
                TreeList.Add(tree);
            }
            return TreeList;
        }

        public List<Base_Module> GetBase_ModuleByParent(long parent = 0)
        {
            List<Base_Module> list = _dbSession.Base_ModuleDal.Entities().Where(o => o.ParentId == parent).OrderBy(o => o.ParentId).ThenBy(o => o.SortCode).ToList();
            return list;
        }

        public void AddBase_Module(Base_Module model)
        {
            _dbSession.Base_ModuleDal.Add(model);
            _dbSession.UnitWork.Commit();
        }

        public void UpdateBase_Module(Base_Module model)
        {
            _dbSession.Base_ModuleDal.Update(model);
            _dbSession.UnitWork.Commit();
        }

        public void DeleteBase_Module(Base_Module model)
        {
            _dbSession.Base_ModuleDal.Delete(model);
            _dbSession.UnitWork.Commit();
        }


        public List<Base_Button> GetBase_ButtonByModule(long module)
        {
            var list = _dbSession.Base_ButtonDal
                .Entities()
                .Where(o => o.ModuleId == module && o.unbl != 1 && o.DeleteMark != 1)
                .OrderBy(o => o.Category)
                .ThenBy(o => o.SortCode)
                .AsNoTracking()
                .ToList();
            foreach (var item in list)
            {
                item.Category = (item.Category == "1" ? "工具栏" : "右键栏");
            }
            return list;
        }

        public Base_Button GetBaseButton(long buttonid)
        {
            return _dbSession.Base_ButtonDal.Entities().FirstOrDefault(o => o.ButtonId == buttonid);
        }

        public void AddBase_Button(Base_Button model)
        {
            model.unbl = 0;
            model.DeleteMark = 0;
            _dbSession.Base_ButtonDal.Add(model);
            _dbSession.UnitWork.Commit();
        }

        public void UpdateBase_Button(Base_Button model)
        {
            _dbSession.Base_ButtonDal.Update(model);
            _dbSession.UnitWork.Commit();
        }

        public void DeleteBase_Button(Base_Button model)
        {
            model.DeleteMark = 1;
            model.unbl = 1;
            _dbSession.Base_ButtonDal.Update(model);
            _dbSession.UnitWork.Commit();
        }
    }
}

using BusinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Product> getProductList()
        {
            var pros = new List<Product>();
            try
            {
                using var context = new FStoreDBAssignmentContext();
                pros = context.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return pros;
        }

        public Product getProductByID(int productID)
        {
            Product pro = null;
            try
            {
                using var context = new FStoreDBAssignmentContext();
                pro = context.Products.SingleOrDefault(p => p.ProductId == productID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return pro;
        }

        public void addNew(Product pro)
        {
            try
            {
                Product product = getProductByID(pro.ProductId);
                if (product == null)
                {
                    using var context = new FStoreDBAssignmentContext();
                    context.Products.Add(pro);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The product is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void update(Product pro)
        {
            try
            {
                Product product = getProductByID(pro.ProductId);
                if (product != null)
                {
                    using var context = new FStoreDBAssignmentContext();
                    context.Products.Update(pro);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The product does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void remove(int productID)
        {
            try
            {
                Product pro = getProductByID(productID);
                if (pro != null)
                {
                    using var context = new FStoreDBAssignmentContext();
                    context.Products.Remove(pro);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The product does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

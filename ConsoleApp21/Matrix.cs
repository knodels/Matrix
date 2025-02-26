using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    class Matrix
    {
        private double[,] _matrix;
        private int _rows;
        private int _col;
        private int Rows=>_rows;
        private int Columns=>_col;
        
        public Matrix(int rows,int colums)
        {
            _rows = rows;
            _col = colums;
            _matrix = new double[_rows,_col];
        }
        public Matrix(int rows,int colums,double element):this(rows,colums)
        {
            for(int i = 0; i < _rows; i++)
            {
                for(int j = 0; j < _col; j++)
                {
                    _matrix[i,j] = element;
                }
            }
        }
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _col; j++) 
                {
                    res += $"{_matrix[i, j],-6}";
                }
                if (i < Rows-1)
                {
                    res += "\n";
                }               
            }
            return res;
        }
        #region overide
        public override bool Equals(object obj)
        {
            return obj is Matrix matrix &&
                   EqualityComparer<double[,]>.Default.Equals(_matrix, matrix._matrix) &&
                   _rows == matrix._rows &&
                   _col == matrix._col &&
                   Rows == matrix.Rows &&
                   Columns == matrix.Columns;
        }

        public override int GetHashCode()
        {
            int hashCode = -2095806138;
            hashCode = hashCode * -1521134295 + EqualityComparer<double[,]>.Default.GetHashCode(_matrix);
            hashCode = hashCode * -1521134295 + _rows.GetHashCode();
            hashCode = hashCode * -1521134295 + _col.GetHashCode();
            hashCode = hashCode * -1521134295 + Rows.GetHashCode();
            hashCode = hashCode * -1521134295 + Columns.GetHashCode();
            return hashCode;
        }

        public static Matrix operator *(Matrix a,double b)
        {
            Matrix res = new Matrix(a.Rows,a.Columns);
            for(int i=0;i<a.Rows; i++)
            {
                for(int j = 0; j < a.Columns; j++)
                {
                    res._matrix[i, j] = a._matrix[i, j] * b;
                }
            }
            return res;
        }
        public static Matrix operator +(Matrix a) => a;//унарный плюс
        public static Matrix operator -(Matrix a)
        {
            return a * (-1);
        }//унарный минус
        public static bool operator ==(Matrix a,Matrix b)
        {
            if(a.Rows != b.Rows || a.Columns != b.Columns)
            {
                return false;
            }
            for(int i = 0; i < a.Rows; i++)
            {
                for(int j=0;j< a.Columns; j++)
                {
                    if (a._matrix[i, j] != b._matrix[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        } //равенство
        public static bool operator !=(Matrix a,Matrix b)
        {
            return !(a == b);
        }//неравенство
        public static Matrix operator +(Matrix a,Matrix b)//бинарный плюс
        {
            if (a.Rows == b.Rows || a.Columns != b.Columns)
            {
                throw new ArgumentException("Разная размереность матриц!");
            }
            Matrix res = new Matrix(a.Rows, a.Columns);
            for(int i = 0; i < a.Rows; i++)
            {
                for(int j = 0; j < a.Columns; j++)
                {
                    res._matrix[i,j]=a._matrix[i,j]+b._matrix[i,j];
                }
            }
            return res;
            
        }
        public static Matrix operator -(Matrix a,Matrix b)
        {
            return a + b * (-1);
        }//бианрный минус
        public static Matrix operator *(Matrix a,Matrix b)//умножение матриц
        {
            if (a.Columns != b.Rows) throw new ArgumentException("Нарушение размеров матриц!");
            Matrix res = new Matrix(a.Rows,b.Columns);
            
            for(int i =0;i<a.Rows; i++)
            {
                for(int j=0;j<b.Columns; j++)
                {
                    for (int k = 0; k < a.Columns; k++)
                    {
                        res._matrix[i,j] += (a._matrix[i, k] * b._matrix[k, j]);
                    }
                }
            }

            return res;
        }
        #endregion
        public Matrix(int rows,int columns, double[]elements,bool refill= false,double filling=0):this(rows,columns)
        {
            
            if (rows * columns != elements.Length && !refill)
            {
                throw new ArgumentException("Кол-во элементов массива не соответствует кол-ву элементов матрицы!");
            }
            int k = 0;
            for(int i = 0; i < Rows; i++)
            {
                for(int j = 0; j < Columns; j++)
                {
                    if((Rows* Columns >elements.Length) && k == elements.Length)
                    {
                        return;
                    }
                    _matrix[i,j]=elements[k];
                    k++;
                }              
            }      
        }      
        public Matrix(int rows, int columns,bool isSingle =false) : this(rows,columns)
        {
            _rows=rows;
            _col=columns;
            _matrix = new double[_rows, _col];
            if (isSingle)
            {
                if (rows != columns) throw new ArgumentException("Единичная матрица должна быть квадратной");
                _matrix = new double[_rows, _col];
                
                for (int i = 0; i < rows; i++)
                {
                    
                        _matrix[i,i]= 1;
                    
                }
            }
        }
        //транспонирование
        public Matrix Transpise()
        {
            Matrix res = new Matrix(Columns,Rows);
            for(int i = 0; i < Rows; i++)
            {
                for(int j=0; j < Columns; j++)
                {
                    res._matrix[j,i] = _matrix[i, j];
                }
            }
            return res;
        }
        public Matrix Single(int rc)
        {
            Matrix res = new Matrix(rc, rc);
            for(int i = 0; i < rc; i++)
            {
                for(int j=0; j < rc; j++)
                {
                    if(i == j)
                        res._matrix[i, j] = 1;
                    else
                    {
                        res._matrix[i,j]= 0;
                    }
                }
            }
            return res;
        }
    }
}

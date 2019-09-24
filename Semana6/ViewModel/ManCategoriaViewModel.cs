using Semana6.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Semana6.ViewModel
{
	public class ManCategoriaViewModel : ViewModelBase
	{
		int _ID;

		public int ID
		{
			get { return _ID; }
			set
			{
				if (_ID != value)
				{
					_ID = value;
					OnPropertChanged();
				}
			}
		}

		string _Nombre;

		public string Nombre
		{
			get { return _Nombre; }
			set
			{
				if (_Nombre != value)
				{
					_Nombre = value;
					OnPropertChanged();
				}
			}
		}

		string _Descripcion;

		public string Descripcion
		{
			get { return _Descripcion; }
			set
			{
				if (_Descripcion != value)
				{
					_Descripcion = value;
					OnPropertChanged();
				}
			}
		}

		public ICommand GrabarCommand { get; set; }
		public ICommand CerrarCommand { get; set; }
		public ICommand EliminarCommand { get; set; }

		public ManCategoriaViewModel()
		{
			GrabarCommand = new RelayCommand<object>(
				o =>
				{
					if (ID > 0)
					{
						new CategoriaModel().Actualizar(new Entity.Categoria
						{
							IdCategoria = ID,
							NombreCategoria = Nombre,
							Descripcion = Descripcion
						});
					}

					else
					{
						new CategoriaModel().Insertar(new Entity.Categoria
						{
							NombreCategoria = Nombre,
							Descripcion = Descripcion
						});
	
					}

					
										
				});

			CerrarCommand = new RelayCommand<Window>(
				param => Cerrar(param)
				);
		}

		void Cerrar(Window window)
		{
			window.Close();
		}
	}
}

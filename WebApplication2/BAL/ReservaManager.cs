using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WebApplication2.Data;

namespace BAL
{
    public class ReservaManager
    {
        BaseDatos db = new BaseDatos();


        public List<ReservaModelo> Listar()
        {
            var lista = (from r in db.reserva
                         join h in db.habitacion on r.idhabitacion equals h.idhabitacion
                         join c in db.cliente on r.idcliente equals c.idcliente
                         select new ReservaModelo
                         {
                             idreserva = r.idreserva,
                             idhabitacion = r.idhabitacion,
                             idcliente = r.idcliente,
                             fecha = r.fecha,
                             numdias = r.numdias,
                             fechaout = r.fechaout,
                             total = r.total,
                             estado = r.estado,
                             // Habitación
                             numhab = h.numhab,
                             detalle = h.detalle,
                             valordia = h.valordia,
                             // Cliente
                             nombres = c.nombres,
                             apellidos = c.apellidos,
                             email = c.email,
                             telefono = c.telefono
                         }).ToList();
            return lista;
        }


        public ReservaModelo Buscar(int id)
        {
            ReservaModelo obj = (from r in db.reserva
                       join h in db.habitacion on r.idhabitacion equals h.idhabitacion
                       join c in db.cliente on r.idcliente equals c.idcliente
                       where r.idreserva == id
                       select new ReservaModelo
                       {
                           idreserva = r.idreserva,
                           idhabitacion = r.idhabitacion,
                           idcliente = r.idcliente,
                           fecha = r.fecha,
                           numdias = r.numdias,
                           fechaout = r.fechaout,
                           total = r.total,
                           estado = r.estado,
                           // Habitación
                           numhab = h.numhab,
                           detalle = h.detalle,
                           valordia = h.valordia,
                           // Cliente
                           nombres = c.nombres,
                           apellidos = c.apellidos,
                           email = c.email,
                           telefono = c.telefono
                       }).FirstOrDefault();
            return obj;
        }

        public int Crear(ReservaModelo obj)
        {
            try {
                var entidad = new reserva();
                entidad.idhabitacion = obj.idhabitacion;
                entidad.idcliente = obj.idcliente;
                entidad.fecha = obj.fecha;
                entidad.numdias = 2;
                entidad.fechaout = obj.fechaout;
                entidad.total = 100000;
                entidad.estado = 0;


                db.reserva.AddOrUpdate(entidad);
                db.SaveChanges();

                return entidad.idreserva;
            }
            catch (Exception exe)
            {
                return 0;
            }

        }

        public int Editar(ReservaModelo obj)
        {
            try
            {
                var entidad = db.reserva.Find(obj.idreserva);
            entidad.idhabitacion = obj.idhabitacion;
            entidad.idcliente = obj.idcliente;
            entidad.fecha = obj.fecha;
            entidad.numdias = 2;
            entidad.fechaout = obj.fechaout;
            entidad.total = 100000;
            entidad.estado = 0;


            db.reserva.AddOrUpdate(entidad);
            db.SaveChanges();

            return entidad.idreserva;
            }
            catch (Exception exe)
            {
                return 0;
            }
        }


        public int Borrar(int id)
        {
                try
                {
                    var entidad = db.reserva.Find(id);
            db.reserva.Remove(entidad);
            db.SaveChanges();
            return entidad.idreserva;
            }
            catch (Exception exe)
            {
                return 0;
            }
        }


        public List<ListasModel> Habitaciones()
        {
            var man = new ListasManager();
            return man.Habitaciones();
        }

        public List<ListasModel> Clientes()
        {
            var man = new ListasManager();
            return man.Clientes();
        }
    }
}
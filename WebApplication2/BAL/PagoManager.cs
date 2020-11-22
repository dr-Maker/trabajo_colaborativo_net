using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WebApplication2.Data;


namespace BAL
{
    public class PagoManager
    {

        BaseDatos db = new BaseDatos();

        public List<PagoModelo> Listar()
        {
            var lista = (from r in db.reserva
                         join h in db.habitacion on r.idhabitacion equals h.idhabitacion
                         join c in db.cliente on r.idcliente equals c.idcliente
                         join p in db.pago on r.idreserva equals p.idreserva

                         select new PagoModelo
                         {
                             idpago = p.idpago,
                             montopago = p.montopago,
                             estadopago = p.estado,
                             //Reserva
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


        public PagoModelo Buscar(int id)
        {
            var obj = (from r in db.reserva
                              join h in db.habitacion on r.idhabitacion equals h.idhabitacion
                              join c in db.cliente on r.idcliente equals c.idcliente
                              join p in db.pago on r.idreserva equals p.idreserva
                              where p.idpago == id
                              select new PagoModelo
                              {
                                  idpago = p.idpago,
                                  montopago = p.montopago,
                                  estadopago = p.estado,
                                  //Reserva
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


        public int Crear(PagoModelo obj)
        {
            var entidad = new pago();
            entidad.idreserva = obj.idreserva;
            entidad.montopago = obj.montopago;
            entidad.estado = 0;
            db.pago.AddOrUpdate(entidad);
            db.SaveChanges();

            return entidad.idpago;
        }

        public int Editar(PagoModelo obj)
        {
            var entidad = db.pago.Find(obj.idpago);
            entidad.idreserva = obj.idreserva;
            entidad.montopago = obj.montopago;

            entidad.estado = 0;
            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();

            return entidad.idpago;
        }


        public int Borrar(int id)
        {
            var entidad = db.pago.Find(id);
            db.pago.Remove(entidad);
            db.SaveChanges();
            return entidad.idpago;
        }

        public List<ListasModel> Reservas()
        {
            var man = new ListasManager();
            return man.Reservas();

        }
    }
    
}
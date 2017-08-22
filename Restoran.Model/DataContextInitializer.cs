using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Restoran.Model
{
    public class DataContextInitializer :  DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {

            IList<MstPegawai> mstPegawai = new List<MstPegawai>();

            mstPegawai.Add(new MstPegawai()
            {
                ID = 1,
                KodePegawai ="KP001",
                NamaLengkap ="Handra Pratama",
                JenisKelamin ="Laki-Laki",
                Alamat ="Jl. Lubuk Linggau",
                Email ="HandraPratama@gmail.com",
                Status ="Aktif"

            });

            mstPegawai.Add(new MstPegawai()
            {
                ID = 2,
                KodePegawai = "KP002",
                NamaLengkap = "Novitasari",
                JenisKelamin = "Perempuan",
                Alamat = "Jl. Cilendek Timur",
                Email = "Fisnovit@gmail.com",
                Status = "Aktif"

            });

            foreach (MstPegawai item in mstPegawai)
            {
                context.mstPegawai.Add(item);
            }
            base.Seed(context);

            IList<MstKeanggotaan> mstDaftarmenu = new List<MstKeanggotaan>();

            mstDaftarmenu.Add(new MstKeanggotaan()
            {
                ID = 1,
                KodeKeanggotaan = "KK001",
                KodeTipeKeanggotaan = "KTK001",
                NomerIdentitas ="3217100000001",
                NamaLengkap = "Spongebob Squerpants",
                Alamat ="Jl.Bikini Bottom Rumah Nanas",
                NomerHandphone = "089898989898",
                Email ="Spongebob@gmail.com"

            });

            mstDaftarmenu.Add(new MstKeanggotaan()
            {
                ID = 1,
                KodeKeanggotaan = "KK002",
                KodeTipeKeanggotaan = "KTK002",
                NomerIdentitas = "3217100000002",
                NamaLengkap = "Patrick Star",
                Alamat = "Jl.Bikini Bottom Rumah Batu",
                NomerHandphone = "085757575757",
                Email = "Patrick@gmail.com"

            });
            foreach (MstKeanggotaan item in mstDaftarmenu)
            {
                context.mstKeanggotaan.Add(item);
            }
            base.Seed(context);


            IList<MstTipeKeanggotaan> mstTipeKeanggotaan = new List<MstTipeKeanggotaan>();

            mstTipeKeanggotaan.Add(new MstTipeKeanggotaan()
            {
                ID = 1,
                KodeTipeKeanggotaan = "KTK001",
                JenisKeanggotaan ="Silver",
                Diskon="5%"

            });

            mstTipeKeanggotaan.Add(new MstTipeKeanggotaan()
            {
                ID = 1,
                KodeTipeKeanggotaan = "KTK002",
                JenisKeanggotaan = "Gold",
                Diskon = "10%"

            });
            mstTipeKeanggotaan.Add(new MstTipeKeanggotaan()
            {
                ID = 1,
                KodeTipeKeanggotaan = "KTK003",
                JenisKeanggotaan = "Platinum",
                Diskon = "15%"

            });
            foreach (MstTipeKeanggotaan item in mstTipeKeanggotaan)
            {
                context.mstTipeKeanggotaan.Add(item);
            }
            base.Seed(context);


            IList<MstDaftarMenu> mstDaftarMenu = new List<MstDaftarMenu>();

            mstDaftarMenu.Add(new MstDaftarMenu()
            {
                ID = 1,
                KodeDaftarMenu = "DM001",
                KodeKategoriMenu = "KM001",
                NamaMenu ="Steak",
                Harga = 100.000,
                Status = "Ada"
            });

            mstDaftarMenu.Add(new MstDaftarMenu()
            {
                ID = 1,
                KodeDaftarMenu = "DM002",
                KodeKategoriMenu = "KM002",
                NamaMenu = "Jus Kiwi",
                Harga = 30.000,
                Status = "Habis"
            });
            foreach (MstDaftarMenu item in mstDaftarMenu)
            {
                context.mstDaftarMenu.Add(item);
            }
            base.Seed(context);


            IList<MstKategoriMenu> mstKategoriMenu = new List<MstKategoriMenu>();

            mstKategoriMenu.Add(new MstKategoriMenu()
            {
                ID = 1,
                KodeKategoriMenu = "KM001",
                NamaKategoriMenu = "Makanan"
                

            });
             mstKategoriMenu.Add(new MstKategoriMenu()
            {
                ID = 2,
                KodeKategoriMenu = "KM002",
                NamaKategoriMenu = "Minuman"
            });

             mstKategoriMenu.Add(new MstKategoriMenu()
             {
                 ID = 3,
                 KodeKategoriMenu = "KM003",
                 NamaKategoriMenu = "Menu Paket"
             });
             mstKategoriMenu.Add(new MstKategoriMenu()
             {
                 ID = 4,
                 KodeKategoriMenu = "KM004",
                 NamaKategoriMenu = "Menu Porsi"
             });

            foreach (MstKategoriMenu item in mstKategoriMenu)
            {
                context.mstKategoriMenu .Add(item);
            }
            base.Seed(context);

            IList<MstMeja> mstMeja = new List<MstMeja>();

            mstMeja.Add(new MstMeja()
            {
                ID = 1,
                KodeMeja = "M001",
                KodeTipeRuangan ="R001",
                NomerMeja=1,
                Status="Ada"
            });

            mstMeja.Add(new MstMeja()
            {
                ID = 2,
                KodeMeja = "M002",
                KodeTipeRuangan = "R002",
                NomerMeja = 2,
                Status = "Ada"
            });

            foreach (MstMeja item in mstMeja)
            {
                context.mstMeja.Add(item);
            }
            base.Seed(context);

            IList<MstTipeRuangan> mstTipeRuangan = new List<MstTipeRuangan>();

            mstTipeRuangan.Add(new MstTipeRuangan()
            {
                ID = 1,
                KodeTipeRuangan = "R001",
                JenisRuangan = "VIP",
                Status = "Ada",
                BiayaRuangan= 100.000
            });

            mstTipeRuangan.Add(new MstTipeRuangan()
            {
                ID = 2,
                KodeTipeRuangan = "R002",
                JenisRuangan = "Outdor",
                Status="Habis",
                BiayaRuangan = 50.000
            });

            mstTipeRuangan.Add(new MstTipeRuangan()
            {
                ID = 3,
                KodeTipeRuangan = "R003",
                JenisRuangan = "Smoking Room",
                Status = "Ada",
                BiayaRuangan = 50.000
            });

            foreach (MstTipeRuangan item in mstTipeRuangan)
            {
                context.mstTipeRuangan.Add(item);
            }
            base.Seed(context);

        }
    } 
}

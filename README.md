# Olivia's Nightmares

Selamat datang di repositori resmi **Olivia's Nightmares**, sebuah proyek game horror yang dikembangkan menggunakan Unity Engine.

## 📌 Tentang Proyek
Game ini menggunakan berbagai aset 3D eksternal yang diunduh secara online untuk menyusun lingkungan, karakter, dan mekanisme interaksi di dalam game. 

Untuk menjaga ukuran repositori tetap ringan dan mematuhi hak cipta/lisensi aset, beberapa aset pihak ketiga tidak dimasukkan langsung ke dalam Git, melainkan harus diunduh secara manual oleh developer melalui daftar yang tersedia di [assets.md](assets.md).

---

## 🛠️ Tutorial Memasukkan Assets ke Folder `assets/AssetsOnline`

Karena proyek ini menggunakan aset eksternal, Anda perlu mengunduh aset tersebut terlebih dahulu dan memasukkannya ke dalam folder khusus agar proyek Unity dapat berjalan dengan benar (menghindari *missing prefab/model*).

Ikuti langkah-langkah berikut:

### Langkah 1: Buka Daftar Aset
Buka file `assets.md` yang ada di repositori ini untuk melihat tautan unduhan resmi dari Sketchfab, CGTrader, dan Unity Asset Store.

### Langkah 2: Unduh Aset Sesuai Format
1. **Dari Sketchfab / CGTrader (Karakter, Kunci, Senter, Hantu):**
   * Unduh dalam format yang didukung Unity (direkomendasikan **.FBX** atau **.OBJ** beserta teksturnya).
   * Ekstrak file `.zip` hasil unduhan jika berbentuk arsip.
2. **Dari Unity Asset Store (Furniture Packs):**
   * Pastikan Anda sudah *Add to My Assets* menggunakan akun Unity Anda.

### Langkah 3: Pindahkan ke Folder `AssetsOnline`
1. Buka folder proyek Unity Anda lewat File Explorer atau langsung di dalam editor Unity.
2. Cari atau buat folder dengan struktur berikut: `[Project-Root]/Assets/AssetsOnline/` (perhatikan kapitalisasi folder).
3. **Untuk Aset 3D Manual (Sketchfab/CGTrader):** 
   * Buat sub-folder baru di dalam `AssetsOnline` sesuai nama aset (contoh: `Assets/AssetsOnline/Kara_Character/` atau `Assets/AssetsOnline/Key/`).
   * Masukkan file 3D (.fbx/.obj) dan folder `Textures` ke dalamnya.
4. **Untuk Aset dari Unity Asset Store:**
   * Buka proyek Unity Anda.
   * Pergi ke menu **Window > Package Manager**.
   * Ubah filter menjadi **My Assets**, cari aset furniture yang terdaftar, lalu klik **Download** dan **Import**.
   * Pindahkan folder hasil import tersebut dari root `Assets/` ke dalam folder `Assets/AssetsOnline/` agar struktur proyek tetap rapi.

### Langkah 4: Selesai & Verifikasi
Buka proyek Unity Anda, tunggu proses *importing* selesai, dan pastikan tidak ada error terkait objek/material yang hilang pada Scene utama.

---

## 🚀 Kontribusi
Jika Anda ingin berkontribusi pada pengembangan game ini:
1. Fork repositori ini.
2. Buat fitur baru Anda pada branch terpisah (`git checkout -b fitur-baru`).
3. Lakukan Commit dan Push.
4. Ajukan *Pull Request*.

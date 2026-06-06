# Orjeen Stok Takip - Giyim Mağazası Otomasyonu (OOP Dönem Ödevi) 👕📊
### Orjeen Stock Tracking - Clothing Store Automation (OOP Term Project)

---

## 🇹🇷 Türkçe Tanıtım

Bu proje, **Nesne Tabanlı Programlama (OOP) dersi dönem ödevi** kapsamında geliştirilmiştir. Projede örnek senaryo olarak hayali bir giyim mağazası olan "Orjeen Giyim Mağazası" temel alınmıştır. 

Gelişmiş koyu tema (dark mode) tasarımı, Supabase bulut veritabanı entegrasyonu ve Gemini Yapay Zeka desteği ile modern masaüstü stok ve ciro takip otomasyonudur.

### 🚀 Öne Çıkan Özellikler
*   **🔒 Supabase Auth & Rol Yönetimi:** Güvenli e-posta/şifre ile kayıt olma, giriş yapma ve rol tabanlı (Staff/Admin) kontrol mekanizmaları.
*   **👕 Barkod Destekli Ürün Yönetimi:** Barkod, marka, beden, renk, alış fiyatı, satış fiyatı, mevcut stok ve kritik stok eşiği bazlı ürün yönetimi.
*   **📁 Kategori Yönetimi:** Ürünleri kategorize etme ve ilişkisel veritabanı yapısı.
*   **🛒 Satış ve Stok Girişi:** Barkod okutarak hızlı stok girişi/çıkışı (IN/OUT) gerçekleştirebilme, yetersiz stok durumunda görsel uyarılar ve gerçek zamanlı (tarih/saat) veri kaydı.
*   **💵 Gelişmiş Ciro Takibi:** Günlük anlık durum, geçmişe yönelik belirli gün veya tarih aralığı filtreleri; toplam satış, alış giderleri ve kâr durumunu izleme.
*   **🤖 Yapay Zeka Stok Danışmanı (Gemini API):** Arka planda stok ve kritik seviyedeki ürün verilerini okuyarak sipariş önerileri, en çok satan ürün analizleri ve mağaza performansı hakkında rehberlik sunan sohbet arayüzü.

### 🛠️ Kullanılan Teknolojiler
*   **Platform:** .NET 8.0 (Windows Forms C#)
*   **Veritabanı:** Supabase (PostgreSQL, Postgrest Client)
*   **Yapay Zeka API:** Google Gemini REST API (`gemini-flash-latest`)
*   **Tasarım Dili:** Premium Dark Theme & Glassmorphism

---

## 🇬🇧 English Description

This project has been developed as a **term project for the Object-Oriented Programming (OOP) course**. It uses a fictitious clothing brand named "Orjeen Giyim Mağazası" as a sample application scenario.

It is a modern desktop stock and revenue tracking automation application featuring an advanced dark theme UI, Supabase cloud database integration, and Google Gemini AI assistant.

### 🚀 Key Features
*   **🔒 Supabase Auth & Role Management:** Secure email/password registration, login, and role-based (Staff/Admin) control mechanisms.
*   **👕 Barcode Supported Product Management:** Product tracking based on barcode, brand, size, color, purchase/sales price, current stock, and critical stock threshold.
*   **📁 Category Management:** Structured categorization of products with a relational database layout.
*   **🛒 Sales & Stock Movements:** Barcode-scanning support for stock entry/exit (IN/OUT), visual warnings on low stock, and real-time transaction timestamp logging.
*   **💵 Advanced Revenue Tracking:** Filter by single day or custom date ranges to track total sales, purchase expenses, and net profit/loss.
*   **🤖 AI Stock Assistant (Gemini API):** An interactive chat interface that analyzes current inventory and critical stocks to provide order recommendations and store performance insights.

### 🛠️ Tech Stack
*   **Platform:** .NET 8.0 (Windows Forms C#)
*   **Database:** Supabase (PostgreSQL, Postgrest Client)
*   **AI Engine API:** Google Gemini REST API (`gemini-flash-latest` model)
*   **UI Design:** Premium Dark Theme & Glassmorphism

---

## 📋 Veritabanı Şeması / Database Schema (PostgreSQL)

```sql
-- 1. Kategoriler / Categories
CREATE TABLE categories (
    id UUID DEFAULT gen_random_uuid() PRIMARY KEY,
    name VARCHAR(100) NOT NULL UNIQUE,
    description TEXT,
    created_at TIMESTAMP WITH TIME ZONE DEFAULT timezone('utc'::text, now()) NOT NULL
);

-- 2. Ürünler / Products
CREATE TABLE products (
    id UUID DEFAULT gen_random_uuid() PRIMARY KEY,
    category_id UUID REFERENCES categories(id) ON DELETE SET NULL,
    barcode VARCHAR(50) NOT NULL UNIQUE,
    name VARCHAR(150) NOT NULL,
    brand VARCHAR(100),
    color VARCHAR(50),
    size VARCHAR(20),
    purchase_price DECIMAL(10, 2) NOT NULL DEFAULT 0.00,
    sale_price DECIMAL(10, 2) NOT NULL DEFAULT 0.00,
    stock_quantity INTEGER NOT NULL DEFAULT 0,
    min_stock_level INTEGER NOT NULL DEFAULT 5,
    created_at TIMESTAMP WITH TIME ZONE DEFAULT timezone('utc'::text, now()) NOT NULL
);

-- 3. Profiller / Profiles (Supabase Auth Integration)
CREATE TABLE profiles (
    id UUID REFERENCES auth.users ON DELETE CASCADE PRIMARY KEY,
    email VARCHAR(255) NOT NULL UNIQUE,
    full_name VARCHAR(150),
    role VARCHAR(50) DEFAULT 'Staff'::character varying NOT NULL,
    created_at TIMESTAMP WITH TIME ZONE DEFAULT timezone('utc'::text, now()) NOT NULL
);

-- 4. Stok Hareketleri / Stock Movements
CREATE TABLE stock_movements (
    id UUID DEFAULT gen_random_uuid() PRIMARY KEY,
    product_id UUID REFERENCES products(id) ON DELETE CASCADE NOT NULL,
    user_id UUID REFERENCES profiles(id) ON DELETE SET NULL,
    movement_type VARCHAR(10) CHECK (movement_type IN ('IN', 'OUT')) NOT NULL, -- IN: Purchase/Alış, OUT: Sales/Satış
    quantity INTEGER NOT NULL CHECK (quantity > 0),
    unit_price DECIMAL(10, 2) NOT NULL,
    description TEXT,
    created_at TIMESTAMP WITH TIME ZONE DEFAULT timezone('utc'::text, now()) NOT NULL
);
```

> [!TIP]
> **TR:** Supabase RLS (Satır Seviyesi Güvenlik) hatası almamak için aşağıdaki komutlarla RLS'yi kapatabilir veya uygun izin politikaları oluşturabilirsiniz:
> **EN:** To prevent Supabase RLS permissions errors during testing, you can disable RLS or define appropriate policies:
> `ALTER TABLE products DISABLE ROW LEVEL SECURITY;`
> `ALTER TABLE stock_movements DISABLE ROW LEVEL SECURITY;`

---

## ⚙️ Kurulum ve Çalıştırma / Setup & Run

1.  **Repository'i Klonlayın / Clone the repository:**
    ```bash
    git clone https://github.com/kullaniciadi/orjeen-stok-takip.git
    ```
2.  Visual Studio veya tercih ettiğiniz bir IDE ile `.sln` dosyasını açın / **Open the `.sln` file in Visual Studio or your preferred IDE.**
3.  NuGet paketlerini geri yüklemek için projeyi derleyin / **Build the project to restore NuGet packages:**
    ```bash
    dotnet build
    ```
4.  **TR:** Supabase ve Gemini bağlantı ayarları varsayılan olarak gömülüdür. Dilerseniz kendi API anahtarlarınızı uygulama içindeki **Ayarlar** sekmesinden maskelenmiş şekilde güvenle güncelleyebilirsiniz.
    **EN:** Supabase and Gemini credentials are built-in by default. You can also update them securely under the masked input boxes in the **Settings (Ayarlar)** tab of the application.

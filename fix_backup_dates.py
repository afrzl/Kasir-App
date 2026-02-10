"""
Fix tanggal di file backup SQL dari format Indonesia (dd/MM/yyyy HH:mm:ss)
ke format MySQL (yyyy-MM-dd HH:mm:ss)

Cara pakai:
    python fix_backup_dates.py "path/ke/file_backup.sql"

Hasil: file baru dengan suffix _FIXED.sql
"""

import re
import sys
import os

def fix_date(match):
    """Convert dd/MM/yyyy HH:mm:ss to yyyy-MM-dd HH:mm:ss"""
    full = match.group(0)
    day = match.group(1)
    month = match.group(2)
    year = match.group(3)
    time_part = match.group(4)
    
    if time_part and time_part.strip() == "00:00:00":
        return f"{year}-{month}-{day}"
    elif time_part:
        return f"{year}-{month}-{day} {time_part}"
    else:
        return f"{year}-{month}-{day}"

def fix_decimal_comma(match):
    """Convert decimal comma to dot inside quotes: '1500,50' -> '1500.50'"""
    return match.group(0).replace(',', '.')

def fix_sql_file(input_path):
    if not os.path.exists(input_path):
        print(f"ERROR: File tidak ditemukan: {input_path}")
        return
    
    # Output file
    base, ext = os.path.splitext(input_path)
    output_path = base + "_FIXED" + ext
    
    print(f"Membaca: {input_path}")
    
    with open(input_path, 'r', encoding='utf-8') as f:
        content = f.read()
    
    # Pattern: dd/MM/yyyy HH:mm:ss (inside SQL values)
    # Match: 12/09/1980 00:00:00 or 04/02/2023 07:10:10
    date_pattern = r'(\d{2})/(\d{2})/(\d{4})\s+(\d{2}:\d{2}:\d{2})'
    
    count = len(re.findall(date_pattern, content))
    print(f"Ditemukan {count} tanggal dengan format dd/MM/yyyy")
    
    fixed_content = re.sub(date_pattern, fix_date, content)
    
    # Also fix date-only pattern: dd/MM/yyyy (tanpa time)
    date_only_pattern = r"'(\d{2})/(\d{2})/(\d{4})'"
    count2 = len(re.findall(date_only_pattern, fixed_content))
    if count2 > 0:
        print(f"Ditemukan {count2} tanggal tanpa waktu")
        fixed_content = re.sub(date_only_pattern, lambda m: f"'{m.group(3)}-{m.group(2)}-{m.group(1)}'", fixed_content)
    
    with open(output_path, 'w', encoding='utf-8') as f:
        f.write(fixed_content)
    
    print(f"Selesai! File diperbaiki: {output_path}")
    print(f"Total {count + count2} tanggal diperbaiki")

if __name__ == '__main__':
    if len(sys.argv) < 2:
        print("Cara pakai: python fix_backup_dates.py \"path/ke/file_backup.sql\"")
        print()
        # Cari file .sql di direktori saat ini
        sql_files = [f for f in os.listdir('.') if f.endswith('.sql') and 'DB TOKO' in f.upper()]
        if sql_files:
            print("File backup yang ditemukan:")
            for f in sql_files:
                print(f"  - {f}")
        sys.exit(1)
    
    fix_sql_file(sys.argv[1])

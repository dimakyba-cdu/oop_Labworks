import os
import random
import shutil

output_dir = "input_files"

if os.path.exists(output_dir):
    shutil.rmtree(output_dir)
os.makedirs(output_dir, exist_ok=True)

def generate_file(filename, content_type):
    file_path = os.path.join(output_dir, filename)
    with open(file_path, "w") as file:
        if content_type == "valid":
            file.write(f"{random.randint(1, 1000)}\n")
            file.write(f"{random.randint(1, 1000)}\n")
        elif content_type == "invalid":
            file.write("232389,5\n")
            file.write("5\n")
        elif content_type == "overflow":
            file.write(f"{random.randint(2**31, 2**32)}\n")
            file.write(f"{random.randint(2**31, 2**32)}\n")
        elif content_type == "extra_data":
            file.write(f"{random.randint(1, 1000)}\n")
            file.write(f"{random.randint(1, 1000)}\n")
            file.write("extra_line\n")

file_types = ["valid"] * 5 + ["invalid", "overflow", "extra_data"]
missing_files = random.sample(range(10, 30), random.randint(2, 5))

for i in range(10, 30):
    if i in missing_files:
        continue  # Пропускаємо створення деяких файлів
    file_type = random.choice(file_types)
    generate_file(f"{i}.txt", file_type)

print(f"Файли згенеровано у папці '{output_dir}'.")

import os
import random

output_dir = "generated_files"
os.makedirs(output_dir, exist_ok=True)

def generate_file(filename, content_type):
    file_path = os.path.join(output_dir, filename)
    with open(file_path, "w") as file:
        if content_type == "valid":
            file.write(f"{random.randint(1, 1000)}\n")
            file.write(f"{random.randint(1, 1000)}\n")
        elif content_type == "invalid":
            file.write("not_a_number\n")
            file.write("another_non_number\n")
        elif content_type == "overflow":
            file.write(f"{random.randint(2**31, 2**32)}\n")
            file.write(f"{random.randint(2**31, 2**32)}\n")
        elif content_type == "empty":
            pass
        elif content_type == "extra_data":
            file.write(f"{random.randint(1, 1000)}\n")
            file.write(f"{random.randint(1, 1000)}\n")
            file.write("extra_line\n")

file_types = ["valid", "invalid", "overflow", "empty", "extra_data"]
for i in range(10, 30):
    file_type = random.choice(file_types)
    generate_file(f"{i}.txt", file_type)

print(f"Файли згенеровано у папці '{output_dir}'.")

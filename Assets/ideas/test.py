file_path = 'ASAS-CONNECTION-LOG.txt'

with open(file_path, 'r') as file:
	file_content = file.read()

print(file_content)

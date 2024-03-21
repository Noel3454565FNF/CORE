from email.message import EmailMessage
import smtplib

sender = "ASAS-external-relay@outlook.fr"
recipient = "noel345@outlook.fr"
messagePath = "message/Order139.txt"  # Correct file path with file extension

def messageP():
    with open(messagePath, 'r') as file:  # Open the correct file path
        return file.read()  # Read the content of the file

message = messageP()

email = EmailMessage()
email["From"] = sender
email["To"] = recipient
email["Subject"] = "Test Email"
email.set_content(message)

smtp = smtplib.SMTP("smtp-mail.outlook.com", port=587)
smtp.starttls()
smtp.login(sender, "AIRplane78380")
smtp.sendmail(sender, recipient, email.as_string())
smtp.quit()

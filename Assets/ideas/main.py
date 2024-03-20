from flask import Flask, request, Response, render_template

app = Flask(__name__)

# Define path to the text file containing valid credentials
VALID_CREDENTIALS_FILE = 'valid_credentials.txt'

NOELCONNECTED = "Custom message for Noel with correct credentials"
ASASCONNECTIONDENIED = "Custom message for curl with wrong credentials"


tempU = "a"
tempP = "b"



# Function to read valid credentials from the text file
def read_valid_credentials():
    with open(VALID_CREDENTIALS_FILE, 'r') as file:
        return [line.strip().split(',') for line in file]

# Define the list of valid credentials
VALID_CREDENTIALS = read_valid_credentials()

@app.route('/', methods=['GET'])
def index():
    global tempU, tempP
    auth = request.authorization
    if is_curl_request():
        if auth and [auth.username, auth.password] in VALID_CREDENTIALS:
            if auth.username == 'noel' and auth.password == 'Part':
                return NOELCONNECTED
            else:
                return "Custom message for curl with correct credentials"
        else:
            return ASASCONNECTIONDENIED
    elif is_web_browser_request():
        if not auth or [auth.username, auth.password] not in VALID_CREDENTIALS:
            return authenticate()
        else:
            tempU = auth.username
            tempP = auth.password
            return WEBchoose()

def authenticate():
    return Response('Could not verify your credentials.', 401, {'WWW-Authenticate': 'Basic realm="Login Required"'})

def is_curl_request():
    user_agent = request.headers.get('User-Agent')
    return user_agent and 'curl' in user_agent.lower()

def is_web_browser_request():
    user_agent = request.headers.get('User-Agent')
    return user_agent and 'curl' not in user_agent.lower()

def WEBchoose():
    if tempU == "noel":
        return "Welcome, Site Director, You are now connected to the ASAS Mainframe Remotly!"
    elif tempU == "LMER":
        return render_template('LMER.html')
    elif tempU != '':
        return render_template('employe.html')
    else:
        return "Unknown user. Please log in with valid credentials."

if __name__ == '__main__':
    app.run(debug=True)

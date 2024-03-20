from flask import Flask, request, Response, render_template, send_file

app = Flask(__name__)

# Define path to the text file containing valid credentials
VALID_CREDENTIALS_FILE = 'valid_credentials.txt'
ulb_phase_2 = "ULB2_Lyrics.txt"
ULB2_lyrics = 'static/blocked_audio.mp3'


NOELCONNECTED = "Custom message for Noel with correct credentials"
ASASCONNECTIONDENIED = "Custom message for curl with wrong credentials"

tempU = "a"
tempP = "b"
idk = "c"

# Function to read valid credentials from the text file
def read_valid_credentials():
    with open(VALID_CREDENTIALS_FILE, 'r') as file:
        return [line.strip().split(',') for line in file]

# Define the list of valid credentials
VALID_CREDENTIALS = read_valid_credentials()

def is_web_browser_request():
    user_agent = request.headers.get('User-Agent')
    return user_agent and 'curl' not in user_agent.lower()

@app.route('/blocked')
def BLOCKEDONCEAGAIN():
    if is_web_browser_request():
            return render_template('ULB2.html')
def audio_ULB2():
    return send_file(ULB2_lyrics)


@app.route('/', methods=['GET'])
def index():
    global tempU, tempP
    auth = request.authorization
    if not auth or [auth.username, auth.password] not in VALID_CREDENTIALS:
        return authenticate()
    else:
        tempU = auth.username
        tempP = auth.password
        return WEBchoose()

def authenticate():
    return Response('Could not verify your credentials.', 401, {'WWW-Authenticate': 'Basic realm="Login Required"'})

def WEBchoose():
    if tempU == "noel":
        return "Welcome, Site Director, You are now connected to the ASAS Mainframe Remotely!"
    elif tempU == "LMER":
        return render_template('LMER.html')
    elif tempU != '':
        return render_template('employe.html')
    else:
        return "Unknown user. Please log in with valid credentials."

@app.route('/test')
def test_page():
    global tempU, tempP
    auth = request.authorization
    if idk == "a":
        return "HACKER"
    elif not auth or [auth.username, auth.password] not in VALID_CREDENTIALS:
        return authenticate()
    else:
        tempU = auth.username
        tempP = auth.password
        return WEBchoose()

@app.route('/button_clicked', methods=['POST'])
def heh():
    return render_template('MAIN.html')

@app.route('/Main.html')
def tsk():
    return render_template('MAIN.html')

if __name__ == '__main__':
    app.run(debug=True)

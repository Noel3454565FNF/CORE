@app.route('/blocked')
def BLOCKEDONCEAGAIN():
    if is_web_browser_request():
        with open(ulb_phase_2, 'r') as file:
            result1 =  file.read()
            result2 = file.read()
            result3 =  result1 + result1 + result1 + result1 + result1 + result1 + result1
            result4 =  result3 + result3 + result3 + result3 + result3 + result3 + result3
            result5 = result4 + result4 + result4 + result4 + result4 + result4 + result4 + result4 + result4 + result4 + result4 + result4 + result4
            result6 = result5 + result5 + result5 + result5 + result5 + result5 + result5 + result5 + result5 + result5 + result5 + result5 + result5
            result7 = result6 + result6 + result6
            audio_ULB2()
            return result7
def audio_ULB2():
    return send_file(ULB2_lyrics)


import requests
import json
import sys
from telethon.sync import TelegramClient, events
import re
import asyncio



# get_groups:  url = "http://127.0.0.1:19995/api/v3/groups"
# create_profile : url = "http://127.0.0.1:19995/api/v3/profiles/create"
# start_profile url = "http://127.0.0.1:19995/api/v3/profiles/start/{id}"



def get_groups(url):
    response = requests.get(url)
    data = json.loads(response.text)
    Gropus = []
    # Extract and print the 'name' field from the response
    for group in data['data']:
        Gropus.append(group['name'])
    print("-".join(Gropus))

def create_profile(url, name, group_name):
    data = {
        "profile_name" : name,
        "group_name": group_name,
        "browser_core": "chromium",
        "browser_name": "Chrome",
        "browser_version": "129.0.6533.73",
        "is_random_browser_version": False,
        "raw_proxy" : "",
        "startup_urls": "",
        "is_masked_font": True,
        "is_noise_canvas": False,
        "is_noise_webgl": False,
        "is_noise_client_rect": False,
        "is_noise_audio_context": True,
        "is_random_screen": False,
        "is_masked_webgl_data": True,
        "is_masked_media_device": True,
        "is_masked_font": True,
        "is_random_os": False,
        "os": "Windows 11",
        "webrtc_mode": 2,
        "user_agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/129.0.0.0 Safari/537.36"
    }

    response = requests.post(url, data=json.dumps(data))
    print(json.loads(response.text)["data"]["id"])

    
def start_profile(url, id):
    response = requests.get(url.format(id=id))
    response_data = response.json()

    if not response_data.get("success", False):
        print("failed")
    else:
        print(response_data["data"]["remote_debugging_address"] + "-" + str(response_data["data"]["browser_location"]))

async def getOTPCode(session_file, api_id, api_hash):
    client = TelegramClient(session_file, api_id, api_hash)
    otp_code = None  # Biến để lưu OTP

    otp_received = asyncio.Event()  # Sử dụng sự kiện để theo dõi việc nhận OTP

    @client.on(events.NewMessage(from_users=777000))  # Lắng nghe tin nhắn từ Telegram
    async def handle_incoming_message(event):
        nonlocal otp_code
        otp = re.search(r'\b(\d{5})\b', event.raw_text)  # Tìm mã OTP 5 chữ số
        if otp:
            otp_code = otp.group(0)  # Lưu OTP vào biến
            otp_received.set()  # Đánh dấu là đã nhận được OTP
            await client.disconnect()  # Ngắt kết nối sau khi nhận OTP

    async with client:
        try:
            await asyncio.wait_for(otp_received.wait(), timeout=30)  # Chờ tối đa 1 phút
            if otp_code:
                print(otp_code)  # Chỉ in OTP mà không in thêm ký tự nào khác
            return otp_code is not None  # Trả về True nếu có OTP, False nếu không
        except asyncio.TimeoutError:
            await client.disconnect()
            return False  # Trả về False nếu không nhận được OTP trong 1 phút

async def main():
    if sys.argv[1] == "get_groups":
        get_groups(sys.argv[2])  # url
    elif sys.argv[1] == "create_profile":
        create_profile(sys.argv[2], sys.argv[3], sys.argv[4])  # url, name, group_name
    elif sys.argv[1] == "start_profile":
        start_profile(sys.argv[2], sys.argv[3])  # url, id
    elif sys.argv[1] == "getOTPCode":
        result = await getOTPCode(sys.argv[2], sys.argv[3], sys.argv[4])  # session_file, api_id, api_hash
        print(result)  # In ra True nếu nhận được OTP, False nếu không
    else:
        print("false")


if __name__ == "__main__":
    asyncio.run(main())
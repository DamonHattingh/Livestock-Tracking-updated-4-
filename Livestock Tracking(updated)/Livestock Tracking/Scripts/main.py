import cv2
import torch
import numpy as np
from twilio.rest import Client

# Your Twilio Account SID and Auth Token
account_sid = 'AC467d3314af4d8c76c9411537b69106ef'
auth_token = 'fa1682652557b7d7451f1754eab20948'

# Your Twilio phone number
twilio_phone_number = '+12052363623'

# Recipient phone number where you want to send the SMS
recipient_phone_number = '+27661862212'

def main():
    points = []

    def send_sms(message_body):
        client = Client(account_sid, auth_token)

        message = client.messages.create(
            body=message_body,
            from_=twilio_phone_number,
            to=recipient_phone_number
        )

        print(f"SMS sent with SID: {message.sid}")

    def points(event, x, y, flags, param):
        if event == cv2.EVENT_MOUSEMOVE:
            colorsBGR = [x, y]
            print(colorsBGR)

    cv2.namedWindow('FRAME')
    cv2.setMouseCallback('FRAME', points)

    model = torch.hub.load('ultralytics/yolov5', 'custom', path='yolov5s.pt')

    cap = cv2.VideoCapture('Cows.mp4')

    cow_list = []  # List to store tracked cows

    frame_counter = 0
    process_every_n_frames = 2  # Process every second frame
    distance_threshold = 100  # Adjust this threshold as needed

    while True:
        ret, frame = cap.read()
        if not ret:
            break

        frame_counter += 1
        if frame_counter % process_every_n_frames != 0:
            continue

        frame = cv2.resize(frame, (800, 450))  # Resize frame for faster processing

        results = model(frame)

        for index, row in results.pandas().xyxy[0].iterrows():
            x1 = int(row['xmin'])
            y1 = int(row['ymin'])
            x2 = int(row['xmax'])
            y2 = int(row['ymax'])
            d = row['name']
            cx = int((x1 + x2) / 2)
            cy = int((y1 + y2) / 2)
            if 'cow' in d:
                if not any(is_near((cx, cy), cow, distance_threshold) for cow in cow_list):
                    cv2.rectangle(frame, (x1, y1), (x2, y2), (0, 0, 255), 3)
                    cv2.putText(frame, str(d), (x1, y1), cv2.FONT_HERSHEY_PLAIN, 2, (255, 0, 0), 2)
                    cow_list.append((cx, cy))

        cv2.putText(frame, f"Total Cows: {len(cow_list)}", (50, 49), cv2.FONT_HERSHEY_PLAIN, 2, (255, 0, 0), 2)

        cv2.imshow("FRAME", frame)

        key = cv2.waitKey(1)

    cap.release()
    cv2.destroyAllWindows()

    # Send an SMS with the count
    sms_message = f"Total Cows Counted: {len(cow_list)}"
    send_sms(sms_message)

    print("Count of unique cows sent via SMS.")

def is_near(point, cow, threshold):
    cow_center = cow
    distance = np.linalg.norm(np.array(point) - np.array(cow_center))
    return distance < threshold

if __name__ == "__main__":
    main()

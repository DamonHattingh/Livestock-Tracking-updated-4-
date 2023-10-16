import cv2
import torch
import numpy as np
from twilio.rest import Client
import time

# Your Twilio Account SID and Auth Token
account_sid = 'AC467d3314af4d8c76c9411537b69106ef'
auth_token = '32e439d70bb911790a061b997fbdb7f8'

# Your Twilio phone number
twilio_phone_number = '+12052363623'

# Recipient phone number where you want to send the SMS
recipient_phone_number = '+27661862212'

# Define a dictionary to map labels to text file names
label_to_filename = {
    'cow': 'cows.txt',
    'horse': 'horses.txt',
    'sheep': 'sheep.txt',
    'bush_pig': 'bush_pigs.txt',
    'caracal': 'caracals.txt',
    'chicken': 'chickens.txt'
}

# Define the distance threshold for animal detection
distance_threshold = 10  # Adjust this threshold as needed

# Set the desired confidence threshold (e.g., 0.7 for 70% confidence)
confidence_threshold = 0.7


def is_near(point, animal, threshold):
    animal_center = animal
    distance = np.linalg.norm(np.array(point) - np.array(animal_center))
    return distance < threshold


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

    model = torch.hub.load('ultralytics/yolov5', 'custom', path='AllAnimals.pt')

    model.conf = confidence_threshold  # Set the confidence threshold

    # Using the built-in camera (usually camera index 0)
    cap = cv2.VideoCapture(0)

    # Initialize dictionaries to store tracked animals
    animal_lists = {label: [] for label in label_to_filename.keys()}

    # Initialize counters for each label
    animal_counts = {label: 0 for label in label_to_filename.keys()}

    frame_counter = 0
    process_every_n_frames = 1  # Process every second frame

    # Clear animal_lists before starting the timer
    for label in label_to_filename.keys():
        animal_lists[label] = []

    # Set a timer for 15 seconds
    end_time = time.time() + 20

    while time.time() < end_time:
        ret, frame = cap.read()
        if not ret:
            break

        frame_counter += 1
        if frame_counter % process_every_n_frames != 0:
            continue

        frame = cv2.resize(frame, (800, 450))  # Resize frame for faster processing

        results = model(frame)

        for index, row in results.pandas().xyxy[0].iterrows():
            # Filter out detections with confidence below the threshold
            if row['confidence'] < confidence_threshold:
                continue

            x1 = int(row['xmin'])
            y1 = int(row['ymin'])
            x2 = int(row['xmax'])
            y2 = int(row['ymax'])
            label = row['name']
            cx = int((x1 + x2) / 2)
            cy = int((y1 + y2) / 2)
            if label in label_to_filename.keys():
                if not any(is_near((cx, cy), animal, distance_threshold) for animal in animal_lists[label]):
                    cv2.rectangle(frame, (x1, y1), (x2, y2), (0, 0, 255), 3)
                    cv2.putText(frame, str(label), (x1, y1), cv2.FONT_HERSHEY_SIMPLEX, 0.5, (255, 0, 0), 2)
                    animal_lists[label].append((cx, cy))
                    # Update the counter for the detected animal
                    animal_counts[label] += 1

        count_text = "Animals Detected: "
        for label, count in animal_counts.items():
            count_text += f"{label}: {count}  "

        cv2.putText(frame, count_text, (50, 49), cv2.FONT_HERSHEY_SIMPLEX, 0.5, (255, 0, 0), 2)

        cv2.imshow("FRAME", frame)

        key = cv2.waitKey(1)

    cap.release()
    cv2.destroyAllWindows()

    # Save animal counts to text files
    for label, count in animal_counts.items():
        filename = label_to_filename[label]
        with open(filename, "w") as file:
            file.write(str(count) + "\n")

    print("Animal counts saved to text files.")


if __name__ == "__main__":
    main()

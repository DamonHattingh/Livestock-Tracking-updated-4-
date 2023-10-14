from pywinauto.application import Application
import time

# Wait for MAVProxy to fully initialize (adjust the delay as needed)
time.sleep(5)

# Find the MAVProxy main window by its class name
app = Application(backend="uia").connect(class_name="CASCADIA_HOSTING_WINDOW_CLASS")

# Send commands with spaces and delays
commands = [
    "mode guided",
    "arm throttle",
    "takeoff 40",
    "wp load ..\\Tools\\autotest\\Generic_Missions\\morningflight1.txt",
    "mode auto"
]

# Access the main window
main_window = app.window(class_name="CASCADIA_HOSTING_WINDOW_CLASS")

for command in commands:
    # Use with_spaces=True to include explicit spaces between words
    main_window.type_keys(command, with_spaces=True)
    main_window.type_keys('{ENTER}')
    time.sleep(6)  # Pause for 6 seconds before sending the next command

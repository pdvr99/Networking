import socket
import threading

HEADER = 64
PORT = 5050

#get the local ip 
#SERVER = "10.61.2.141"
SERVER = socket.gethostbyname(socket.gethostname())
print(SERVER)

ADDR = (SERVER, PORT)

FORMAT = 'utf-8'

DISCONNECT_MESSAGE = "!DISCONNECT"

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server.bind(ADDR)

#handle the INDIVIDUAL connections between the client and server (one client and one server)
def handle_client(conn, addr):
    print(f"[NEW CONNECTION]{addr} connected.")

    connected = True
    while connected:
        #read as 64-byte message
        
        #how long the message is
        msg_length = conn.recv(HEADER).decode(FORMAT)
        if msg_length: 
            #casts the message length into an int
            msg_length = int(msg_length)
            #How many bytes we recieve
            msg = conn.rec(msg_length).decode(FORMAT)
            if msg == DISCONNECT_MESSAGE:
                connect = False
            print(f"[{addr}] {msg}")
        
    conn.close()


#handle new connections and distribute them where they need to go
def start():
    server.listen()
    print(f"[LISTENING] Server is listening on {SERVER}")
    while True: 
        #when a new connection is made, we pass the connection to handle_client 
        conn, addr = server.accept()
        thread = threading.Thread(target = handle_client, args = (conn, addr))

        #a thread represents a client. Subtract a thread to indicate that there is an active connection
        thread.start()
        print(f"[ACTIVE CONNECTIONS] {threading.activeCount() - 1}")

print("[STARTING] server is starting...")

start()


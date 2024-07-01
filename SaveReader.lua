-- Dump contents of save data from LTTP and send via UDP socket

-- CONSTANTS
local SOCKET = assert(package.loadlib("C:\\ProgramData\\Archipelago\\SNI\\lua/x64/socket-windows-5-1.dll", "luaopen_socket_core"))()
local PORT = 35911
local MAX_FRAMES_FOR_LOOP = 60

-- GLOBAL VARIABLES
local frameCounter  = 0
local udpSocket     = nil
local sramTable     = nil

local function setupUdpSocket()
	local retCode = nil
	local err     = nil

	-- attempt to create the socket
	udpSocket, err = SOCKET:udp()

	-- report error on failure to create socket 
	if err ~= nil then
		print("Unable to create UDP socket!")
		print(err)
		udpSocket = nil
		return
	end

	-- setup UDP peer
	udpSocket:setoption("reuseaddr", true)
	udpSocket:setoption("reuseport", true)
	retCode, err = udpSocket:setpeername("127.0.0.1", PORT)

	-- report error on failure to create socket 
	if err ~= nil then
		print("Unable to setup socket!")
		print(err)
		udpSocket = nil
		return
	end

	print("UDP broadcast setup on localhost:"..PORT.."...")
end

local function main()
	if frameCounter > MAX_FRAMES_FOR_LOOP then
		if udpSocket == nil then
			print("Attempting to setup UDP broadcast...")
			setupUdpSocket()
		else
			-- read the save data into a table
			sramTable = memory.readbyterange(0x7EF000, 0x500)

			-- convert from decimal to raw binary
			for i, data in ipairs(sramTable) do
				sramTable[i] = string.char(data)
			end

			-- send the data via UDP
			udpSocket:send(table.concat(sramTable))
		end

		frameCounter = 0
	else
		frameCounter = frameCounter + 1
	end
end

-- run main() after every frame
emu.registerafter(main)

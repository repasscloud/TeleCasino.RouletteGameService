#!/usr/bin/env bash
set -euo pipefail

API_URL="http://localhost:8080"

echo "🔹 Testing Roulette API endpoint..."
curl -v -X POST \
  "$API_URL/api/Roulette/play?wager=1&betArg=_2nd12&gameSessionId=221" \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d ''

echo "🔹 Testing Roulette video availability..."
ID=$(curl -s -X POST \
  "$API_URL/api/Roulette/play?wager=1&betArg=_2nd12&gameSessionId=221" \
  -H 'accept: application/json' \
  -d '' | jq -r '.videoFile' | sed 's|/app/wwwroot/||')

if [ -z "$ID" ] || [ "$ID" == "null" ]; then
  echo "❌ No video file returned from API"
  exit 1
fi

STATUS=$(curl -s -o /dev/null -w "%{http_code}" "$API_URL/${ID}")

if [ "$STATUS" -ne 200 ]; then
  echo "❌ Video file not available (HTTP $STATUS)"
  exit 1
fi

echo "✅ Roulette API tests passed successfully!"
